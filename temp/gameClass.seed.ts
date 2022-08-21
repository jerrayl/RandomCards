export const GameClassSeed = [
  {
    name: "Berserker",
    description: "Your armor has no effect. Deal x% increased physical damage for each point of armor you have.",
    unique: "Undying rage: Defer all damage for x turns.",
    tags: ["armor", "phys"]
  },
  {
    name: "Warrior",
    description: "Armor limit increased to x. Spend armor instead of mana. Start with x Armor.",
    unique: "Mithril plating: Your maximum health is capped at x. Magic damage does not bypass your armor.",
    tags: ["armor", "phys"]
  },
  {
    name: "Druid",
    description: "Mana limit increased. Leftover mana becomes permanent after x turns. No default mana scaling.",
    unique: "Druidic rite: Take x% of damage to your mana instead of your health",
    tags: ["mana", "magic"]
  },
  {
    name: "Lich",
    description: "Cannot die until all mana has been depleted. Take x times damage to mana when health is at 0",
    unique: "Soul sacrifice: For the next three turns, cards played deduct their mana cost from your health",
    tags: ["mana", "magic"]
  },
  {
    name: "Necromancer",
    description: "Gain x percent of damage dealt as health. Cannot heal.",
    unique: "Blood magic: Your maximum health is capped at x. Do scaling damage to your opponent.",
    tags: ["health", "phys"]
  },
  {
    name: "Cleric",
    description: "Deal x times damage at max health. Deal x times damage when not at max health.",
    unique: "Holy blessing: Restore yourself to max health. For the next two turns, restore yourself to max health and heal your opponent for the amount healed.",
    tags: ["health", "magic"]
  },
  {
    name: "Enchanter",
    description: "All card effects provide a choice one of three cards instead of random cards.",
    unique: "Forbidden knowledge: Draw four abyss cards. Your opponent draws two abyss cards.",
    tags: ["cards"]
  },
  {
    name: "Rogue",
    description: "Gain x% increased damage when you have more than x cards more than your opponent, and x% reduced damage taken when you have more than x cards less than your opponent",
    unique: "Thief’s gambit: Return your hand to the deck, shuffle it, and draw 10 cards.",
    tags: ["cards"]
  }
];

