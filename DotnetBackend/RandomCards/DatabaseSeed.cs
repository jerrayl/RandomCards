﻿using System;
using System.Collections.Generic;
using System.Linq;
using RandomCards.Entities;

namespace RandomCards.Database
{
    public class DatabaseSeed
    {
        public static void Seed(DatabaseContext database)
        {
            var tags = new List<Tag>(){
                new Tag(){
                    Name = "armor"
                },
                new Tag(){
                    Name = "phys"
                },
                new Tag(){
                    Name = "mana"
                },
                new Tag(){
                    Name = "magic"
                },
                new Tag(){
                    Name = "health"
                },
                new Tag(){
                    Name = "cards"
                }
            };

            var classes = new List<Class>(){
                new Class(){
                    Name = "Berserker",
                    Description = "Your armor does not block damage. Deal x% increased physical damage for each point of armor you have.",
                    UniqueAbility = "Undying rage: Defer all damage for x turns."
                },
                new Class(){
                    Name = "Warrior",
                    Description = "Armor limit increased to x. Spend armor instead of mana. Start with x Armor.",
                    UniqueAbility = "Mithril plating: Your maximum health is capped at x. Magic damage does not bypass your armor."
                },
                new Class(){
                    Name = "Druid",
                    Description = "Mana limit increased. Leftover mana becomes permanent after x turns. No default mana scaling.",
                    UniqueAbility = "Druidic rite: Elemental modifiers have their damage and mana cost doubled."
                },
                new Class(){
                    Name = "Lich",
                    Description = "Cannot die until all mana has been depleted. Take x times damage to mana when health is at 0.",
                    UniqueAbility = "Soul sacrifice: For the next three turns, cards played deduct their mana cost from your health."
                },
                new Class(){
                    Name = "Hemomancer",
                    Description = "Gain x percent of damage dealt as health. Cannot heal.",
                    UniqueAbility = "Blood magic: Take x% of your health as direct damage and deal x% of your current health as physical damage to your opponent."
                },
                new Class(){
                    Name = "Cleric",
                    Description = "Deal x% more damage at max health. Deal x% less damage when not at max health.",
                    UniqueAbility = "Holy blessing: Restore yourself to max health. For the next two turns, restore yourself to max health and heal your opponent for the amount healed."
                },
                new Class(){
                    Name = "Enchanter",
                    Description = "Effects that add cards to your deck add twice the number of copies. Your mana scaling is halved.",
                    UniqueAbility = "Forbidden knowledge: Draw four abyss cards. Your opponent draws two abyss cards."
                },
                new Class(){
                    Name = "Rogue",
                    Description = "Take x% less damage for each card you have more than your opponent, and take x% more damage for each card you have less than your opponent.",
                    UniqueAbility = "Thief’s gambit: Return your hand to the deck, shuffle it, and draw 10 cards."
                }
            };

            var classTags = new List<KeyValuePair<string, string>>{
                new KeyValuePair<string, string>("Berserker", "armor"),
                new KeyValuePair<string, string>("Berserker", "phys"),
                new KeyValuePair<string, string>("Warrior", "armor"),
                new KeyValuePair<string, string>("Warrior", "phys"),
                new KeyValuePair<string, string>("Druid", "mana"),
                new KeyValuePair<string, string>("Druid", "magic"),
                new KeyValuePair<string, string>("Lich", "mana"),
                new KeyValuePair<string, string>("Lich", "magic"),
                new KeyValuePair<string, string>("Necromancer", "health"),
                new KeyValuePair<string, string>("Necromancer", "phys"),
                new KeyValuePair<string, string>("Cleric", "health"),
                new KeyValuePair<string, string>("Cleric", "magic"),
                new KeyValuePair<string, string>("Enchanter", "cards"),
                new KeyValuePair<string, string>("Rogue", "cards")
            };

            var attributes = new List<Entities.Attribute>(){
                new Entities.Attribute(){Name = "Health"},
                new Entities.Attribute(){Name = "Mana"},
                new Entities.Attribute(){Name = "Magic Shield"},
                new Entities.Attribute(){Name = "Maximum Health"},
                new Entities.Attribute(){Name = "Maximum Mana"},
                new Entities.Attribute(){Name = "Armor"}
            };

            var modifiers = new List<Modifier>{
                new Modifier(){Name = "add_health_self", Value = 0.4f, Rarity = 5, Description = "Heal for %.", FlavorText = "There's no way I could mess up a simple healing spell, right?"},
                new Modifier(){Name = "add_health_opp", Value = 1f, Rarity = 4, Description = "Heal your opponent for %.", FlavorText = "That was healing touch, not drain touch?"},
                new Modifier(){Name = "slash_self", Value = 1.5f, Rarity = 4, Description = "Deal % damage to yourself.", FlavorText = "Hey, at least I'll get some cool scars out of this."},
                new Modifier(){Name = "slash_opp", Value = 0.4f, Rarity = 6, Description = "Deal % damage to your opponent.", FlavorText = "Here's Johnny!"},
                new Modifier(){Name = "pierce_self", Value = 1.5f, Rarity = 4, Description = "Deal % damage to yourself at the start of each turn for 3 turns.", FlavorText = "Blood magic is always messy."},
                new Modifier(){Name = "pierce_opp", Value = 0.4f, Rarity = 6, Description = "Deal % damage to your opponent at the start of each turn for 3 turns.", FlavorText = "Hold still, I'm gonna stab you just a little."},
                new Modifier(){Name = "bash_self", Value = 1.5f, Rarity = 4, Description = "Deal % damage to yourself for each point of missing health.", FlavorText = "Should have accounted for user error when deciding to use a flail."},
                new Modifier(){Name = "bash_opp", Value = 0.4f, Rarity = 6, Description = "Deal % damage to your opponent for each point of missing health.", FlavorText = "That looks like it's gonna hurt."},
                new Modifier(){Name = "add_mana_self", Value = 0.45f, Rarity = 3, Description = "Increase your mana next turn by %.", FlavorText = "Innervate me!"},
                new Modifier(){Name = "add_mana_opp", Value = 1f, Rarity = 3, Description = "Your opponent starts their next turn with % more mana.", FlavorText = "Do something nice with that, will ya?"},
                new Modifier(){Name = "sub_mana_self", Value = 1.2f, Rarity = 3, Description = "You start your next turn with % less mana.", FlavorText = "Using tomorrow's mana, today."},
                new Modifier(){Name = "sub_mana_opp", Value = 0.8f, Rarity = 3, Description = "Your opponent starts their next turn with % less mana.", FlavorText = "Flushed down the drain."},
                new Modifier(){Name = "add_magicshield_self", Value = 0.3f, Rarity = 4, Description = "Increase your magic shield by %.", FlavorText = "Safety is number one priority."},
                new Modifier(){Name = "add_magicshield_opp", Value = 0.4f, Rarity = 4, Description = "Increase your opponent's magic shield by %.", FlavorText = "I bet it'll weigh them down at least a little."},
                new Modifier(){Name = "sub_magicshield_self", Value = 2f, Rarity = 1, Description = "Reduce your magic shield by %.", FlavorText = "Poor construction!"},
                new Modifier(){Name = "sub_magicshield_opp", Value = 2.5f, Rarity = 1, Description = "Reduce your opponent's magic shield by %.",FlavorText = "All it takes is one good poke."},
                new Modifier(){Name = "add_maxhealth_self", Value = 1.5f, Rarity = 2, Description = "Increase your maximum health by %.", FlavorText = "Don't take 'roids, it gives you horns."},
                new Modifier(){Name = "add_maxhealth_opp", Value = 1.5f, Rarity = 2, Description = "Increase your opponent's maximum health by %.", FlavorText = "It's going on a rampage!"},
                new Modifier(){Name = "sub_maxhealth_self", Value = 1.75f, Rarity = 2, Description = "Decrease your maximum health by %.", FlavorText = "That leg is never gonna be the same again."},
                new Modifier(){Name = "sub_maxhealth_opp", Value = 1.5f, Rarity = 2, Description = "Decrease your opponent's maximum health by %.", FlavorText = "The curse of minification!"},
                new Modifier(){Name = "add_maxmana_self", Value = 5f, Rarity = 1, Description = "Increase your maximum mana by %.", FlavorText = "I see it now. I see it all."},
                new Modifier(){Name = "add_maxmana_opp", Value = 4f, Rarity = 1, Description = "Increase your opponent's maximum mana by %.", FlavorText = "I was hoping it would overload them."},
                new Modifier(){Name = "sub_maxmana_self", Value = 4f, Rarity = 1, Description = "Decrease your maximum mana by %, capped at 5.", FlavorText = "Yup, that sword was cursed."},
                new Modifier(){Name = "sub_maxmana_opp", Value = 4f, Rarity = 1, Description = "Decrease your opponent's maximum mana by %, capped at 5.", FlavorText = "It doesn't feel very pleasant coming up."},
                new Modifier(){Name = "add_armor_self", Value = 3.5f, Rarity = 1, Description = "Increase your armor by %, adding damage reduction each turn.", FlavorText = "Armor up!"},
                new Modifier(){Name = "add_armor_opp", Value = 5f, Rarity = 1, Description = "Increase your opponent's armor by %, adding damage reduction each turn.", FlavorText = "I found a something better, you can have this one."},
                new Modifier(){Name = "sub_armor_self", Value = 3.5f, Rarity = 2, Description = "Reduce your armor by %. Take 2 damage for each point of armor reduced below 0.", FlavorText = "It looked ugly on me, anyway."},
                new Modifier(){Name = "sub_armor_opp", Value = 2.5f, Rarity = 2, Description = "Reduce your opponents armor by %. They take 2 damage for each point of armor reduced below 0.", FlavorText = "That corrosive potion was effective, alright."},
                new Modifier(){Name = "burn_self", Value = 2.2f, Rarity = 2, Description = "Burn yourself, taking % damage at the end of your turn for three turns", FlavorText = "This is fine."},
                new Modifier(){Name = "burn_opp", Value = 1.9f, Rarity = 2, Description = "Burn your opponent, causing them to take % damage at the end of their turn for three turns", FlavorText = "Eat this fireball!"},
                new Modifier(){Name = "freeze_self", Value = 6.7f, Rarity = 1, Description = "Freeze yourself, dealing % damage for each 5 health you currently have.", FlavorText = "The spellbook said iceberg. It didn't say where."},
                new Modifier(){Name = "freeze_opp", Value = 5f, Rarity = 1, Description = "Freeze your opponent, dealing % damage for each 5 health they currently have.", FlavorText = "Winter is coming... For you."},
                new Modifier(){Name = "electrocute_self", Value = 4.5f, Rarity= 2, Description = "Electrocute yourself, dealing % damage.", FlavorText = "Probably shouldn't have cast that lightning spell while wearing plate armor."},
                new Modifier(){Name = "electrocute_opp", Value = 3f, Rarity= 2, Description = "Electrocute your opponent, dealing % damage,", FlavorText = "Zap."},
                new Modifier(){Name = "draw_cards_self", Value = 0.7f, Rarity= 2, Description = "Draw % card(s) from your deck.", FlavorText = "Now that I think about it, there was probably a better use for that teleportation spell."},
                new Modifier(){Name = "draw_cards_opp", Value = 1.15f, Rarity= 2, Description = "Your opponent draws % card(s) from their deck.", FlavorText = "When I said draw, I meant your weapon!"},
                new Modifier(){Name = "destroy_cards_self", Value = 3.5f, Rarity = 2, Description = "Destroy % cards(s) in your hand", FlavorText = "Dissolved? What do you mean, dissolved?"},
                new Modifier(){Name = "destroy_cards_opp", Value = 3.25f, Rarity = 2, Description = "Destroy % cards(s) in your opponent's hand", FlavorText = "Blow it up! Blow it all up!"},
                new Modifier(){Name = "add_cards_self", Value = 2f, Rarity = 2, Description = "Add % random card(s) to your deck.", FlavorText = "These old writings actually contained some pretty useful information."},
                new Modifier(){Name = "add_cards_opp", Value = 2.5f, Rarity = 2, Description = "Add % random card(s) to your opponent's deck.", FlavorText = "I threw a rock at them! How was I supposed to know that it was ore?"},
                new Modifier(){Name = "duplicate_cards_self", Value = 7.5f, Rarity = 2, Description = "Copy % card(s) from your opponent's hand to yours.", FlavorText = "Swiggity Swooty!"},
                new Modifier(){Name = "duplicate_cards_opp", Value = 4f, Rarity = 2, Description = "Copy % card(s) from your hand to your opponent's.", FlavorText = "Hopefully they'll be so confused they won't notice me killing them."}
            };

            // Seed Aliases

            // Seed ModifierTags
        }
    }
}