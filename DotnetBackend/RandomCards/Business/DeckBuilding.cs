using System;
using System.Collections.Generic;
using System.Linq;
using RandomCards.Entities;
using RandomCards.Models;
using RandomCards.Repositories;
using AutoMapper;

namespace RandomCards.Business
{
    public class DeckBuilding : IDeckBuilding
    {
        private IDatabaseRepository<Class> _class;
        private IDatabaseRepository<Account> _account;
        private IDatabaseRepository<Deck> _deck;
        private IDatabaseRepository<Tag> _tag;
        private IDatabaseRepository<Card> _card;
        private IDatabaseRepository<Modifier> _modifier;
        private IDatabaseRepository<CardModifier> _cardModifier;
        private Dictionary<int, string> _tagIdCache = null;
        private Dictionary<string, int> _tagNameCache = null;
        private Dictionary<string, int> _classNameCache = null;
        private List<Modifier> _benefitCache = null;
        private List<Modifier> _drawbackCache = null;
        private IMapper _mapper;
        Random _random;

        private readonly List<int> EFFECT_DISTRIBUTION = new List<int>() { 4, 8, 8, 10, 11, 12, 11, 10, 10, 8, 5, 5 };

        public DeckBuilding(
            IDatabaseRepository<Class> cls,
            IDatabaseRepository<Account> account,
            IDatabaseRepository<Deck> deck,
            IDatabaseRepository<Tag> tag,
            IDatabaseRepository<Card> card,
            IDatabaseRepository<Modifier> modifier,
            IDatabaseRepository<CardModifier> cardModifier,
            IMapper mapper
        )
        {
            _class = cls;
            _account = account;
            _deck = deck;
            _tag = tag;
            _card = card;
            _modifier = modifier;
            _cardModifier = cardModifier;
            _mapper = mapper;
            _random = new Random();
        }

        // TODO: Convert to extension
        private List<Modifier> FilterByTag(List<Modifier> modifiers, string tagName)
        {
            return modifiers.Where(m => m.ModifierTags.Any(mt => mt.TagId.Equals(_tagNameCache[tagName]))).ToList();
        }

        // TODO: Convert to extension
        private T ExtractRandom<T>(List<T> list)
        {
            var i = _random.Next(list.Count);
            var item = list.ElementAt(i);
            list.RemoveAt(i);
            return item;
        }

        private Modifier GetModifierByRarity(List<Modifier> modifiers, List<Modifier> existingModifiers)
        {
            var existingModifierIds = existingModifiers.Select(m => m.Id);
            var filteredModifiers = modifiers.Where(m => !existingModifierIds.Contains(m.Id));
            var totalRarity = filteredModifiers.Sum(m => m.Rarity);
            var rand = _random.NextDouble() * totalRarity;
            foreach (var modifier in filteredModifiers)
            {
                rand -= modifier.Rarity;
                if (rand < 0) return modifier;
            }
            return filteredModifiers.Last();
        }

        private void CreateCache()
        {
            if (_tagIdCache is null || _tagNameCache is null)
            {
                var tags = _tag.Read();
                _tagIdCache = tags.ToDictionary(tag => tag.Id, tag => tag.Name);
                _tagNameCache = tags.ToDictionary(tag => tag.Name, tag => tag.Id);
            }
            if (_classNameCache is null)
            {
                _classNameCache = _class.Read().ToDictionary(cls => cls.Name, cls => cls.Id);
            }
            if (_benefitCache is null || _drawbackCache is null)
            {
                var modifiers = _modifier.Read(m => true, m => m.ModifierTags).ToList();
                _benefitCache = FilterByTag(modifiers, Constants.BENEFIT);
                _drawbackCache = FilterByTag(modifiers, Constants.DRAWBACK);
            }
        }

        private int GetBenefitCount()
        {
            // TODO: Scale by effect
            var rand = _random.Next(10);
            if (rand < 6) return 1;
            return 2;
        }

        private int GetDrawbackCount()
        {
            // TODO: Scale by effect
            var rand = _random.Next(10);
            if (rand < 6) return 1;
            else if (rand < 8) return 2;
            return 0;
        }

        public List<ClassModel> GetClasses()
        {
            CreateCache();
            return _class
                .Read(c => true, c => c.ClassTags)
                .Select(cls =>
                {
                    var classModel = _mapper.Map<Class, ClassModel>(cls);
                    classModel.Tags = cls.ClassTags.Select(t => _tagIdCache[t.TagId]).ToList();
                    return classModel;
                }
                )
                .ToList();
        }

        public List<CardModel> CreateDeck(int accountId, string className, string deckName, out string errorMessage)
        {
            CreateCache();

            errorMessage = null;

            var account = _account.ReadOne(a => a.Id.Equals(accountId));

            if (account is null)
            {
                errorMessage = "Invalid account";
                return null;
            }

            if (!_classNameCache.ContainsKey(className))
            {
                errorMessage = "Invalid class";
                return null;
            }

            var deck = new Deck()
            {
                ClassId = _classNameCache[className],
                AccountId = account.Id,
                Name = deckName,
                Identifier = Guid.NewGuid().ToString().ToLower()
            };

            _deck.Add(deck);

            GenerateCards(deck.Identifier);

            return GetDeckCards(accountId, deck.Identifier, out errorMessage);
        }

        private void GenerateCards(string deckIdentifier)
        {
            var deck = _deck.ReadOne(d => d.Identifier.Equals(deckIdentifier));

            var effectPool = EFFECT_DISTRIBUTION.SelectMany((frequency, i) => Enumerable.Repeat(i, frequency)).ToList();

            for (var sequenceNum = 0; sequenceNum < 90; sequenceNum++)
            {
                var effect = ExtractRandom(effectPool);

                var benefits = new List<Modifier>();
                var drawbacks = new List<Modifier>();

                for (var _ = 0; _ < GetBenefitCount(); _++)
                {
                    benefits.Add(GetModifierByRarity(_benefitCache, benefits));
                }

                for (var _ = 0; _ < GetDrawbackCount(); _++)
                {
                    drawbacks.Add(GetModifierByRarity(_drawbackCache, drawbacks));
                }

                var card = new Card()
                {
                    DeckId = deck.Id,
                    Identifier = Guid.NewGuid().ToString().ToLower(),
                    SequenceNum = (int)Math.Floor((double)sequenceNum / 3)
                };

                _card.Add(card);

                var cardModifiers = new List<CardModifier>();
                var cost = 0d;

                while (benefits.Count > 0)
                {
                    var benefit = ExtractRandom(benefits);
                    var currEffect = Math.Round((effect / (benefits.Count + 1)) * benefit.Value) / benefit.Value;
                    cost += currEffect;
                    cardModifiers.Add(
                        new CardModifier()
                        {
                            CardId = card.Id,
                            ModifierId = benefit.Id,
                            Effect = (float)currEffect
                        }
                    );
                }

                while (drawbacks.Count > 0)
                {
                    var drawback = ExtractRandom(drawbacks);
                    var currEffect = Math.Round((effect / (drawbacks.Count + 1)) * drawback.Value) / drawback.Value;
                    cost += currEffect;
                    cardModifiers.Add(
                        new CardModifier()
                        {
                            CardId = card.Id,
                            ModifierId = drawback.Id,
                            Effect = (float)currEffect
                        }
                    );
                };

                cardModifiers.Aggregate((i, j) => i.Effect > j.Effect ? i : j).IsPrimary = true;

                //GenerateName

                card.Name = "Test card";
                card.Cost = (int)Math.Round(cost);

                _card.Update(card);

                cardModifiers.ForEach(m => _cardModifier.Add(m));
            }
        }

        public List<CardModel> GetDeckCards(int accountId, string deckIdentifier, out string errorMessage)
        {
            errorMessage = null;

            var deck = _deck.ReadOne(d => d.Identifier.Equals(deckIdentifier));

            if (deck is null || !deck.AccountId.Equals(accountId))
            {
                errorMessage = "Invalid deck";
                return null;
            }

            var cards = _card.Read();

            var cardModifiers = _cardModifier
                .Read(cm => cards.Select(c => c.Id).Contains(cm.CardId), cm => cm.Modifier)
                .ToLookup(cm => cm.CardId);

            return cards.Select(card =>
            {
                var cardModel = _mapper.Map<Card, CardModel>(card);
                //var primary = cardModifiers[card.Id].Where(cm => cm.IsPrimary).Single();

                //cardModel.FlavorText = primary.Modifier.FlavorText;
                //cardModel.Image = primary.Modifier.Image;
                cardModel.Modifiers = cardModifiers[card.Id].Select(m => _mapper.Map<CardModifier, CardModifierModel>(m)).ToList();
                return cardModel;
            }).ToList();
        }


        public void SelectCard(int accountId, string cardIdentifier, out string errorMessage)
        {
            errorMessage = null;

            var card = _card.ReadOne(c => c.Identifier.Equals(cardIdentifier), c => c.Deck);

            if (card is null ||
                !card.Deck.AccountId.Equals(accountId) ||
                _card.Read(c => c.SequenceNum != null && c.SequenceNum < card.SequenceNum).Count() > 0)
            {
                errorMessage = "Invalid card";
                return;
            }

            var otherCards = _card.Read(
                c => c.SequenceNum != null &&
                c.SequenceNum == card.SequenceNum &&
                c.Identifier != card.Identifier);

            otherCards.ToList().ForEach(c => _card.Delete(c));

            card.SequenceNum = null;
            _card.Update(card);
        }

        public List<DeckModel> GetDecks(int accountId)
        {
            var decks = _deck.Read(d => d.AccountId.Equals(accountId), d => d.Cards, d => d.Class);

            return decks.Select(d => new DeckModel()
            {
                Name = d.Name,
                Identifier = d.Identifier,
                Class = d.Class.Name,
                IsComplete = d.Cards.Count == 30
            }).ToList();
        }

        public List<int> GetAccountIds()
        {
            return _account.Read().Select(a => a.Id).ToList();
        }
    }
}
