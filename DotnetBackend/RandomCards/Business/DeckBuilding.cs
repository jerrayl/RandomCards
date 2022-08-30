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
        private Dictionary<int, string> _tagCache = null;
        private IMapper _mapper;

        public DeckBuilding(
            IDatabaseRepository<Class> cls,
            IDatabaseRepository<Account> account,
            IDatabaseRepository<Deck> deck,
            IDatabaseRepository<Tag> tag,
            IMapper mapper
        ){
            _class = cls;
            _account = account;
            _deck = deck;
            _tag = tag;
            _mapper = mapper;
        }

        private void CreateCache()
        {
            if (_tagCache is null)
                _tagCache = _tag.Read().ToDictionary(tag => tag.Id, tag => tag.Name);
        }

        public List<ClassModel> GetClasses()
        {
            CreateCache();
            return _class
                .Read(c => true, c => c.ClassTags)
                .Select(cls => {
                    var classModel = _mapper.Map<Class, ClassModel>(cls);
                    classModel.Tags = cls.ClassTags.Select(t => _tagCache[t.TagId]).ToList();
                    return classModel;
                    }
                )
                .ToList();
        }

        public List<CardModel> CreateDeck(int accountId, string className, string deckName)
        {
            return null;
        }

        public List<CardModel> GetDeckCards(int accountId, string deckIdentifier)
        {
            return null;
        }

        public void SelectCard(int accountId, string deckIdentifier, string cardIdentifier) { 

        }
    }
}
