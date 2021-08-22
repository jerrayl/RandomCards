export const ModifierTypeSeed = [
  {
    name: "add_health_self",
    value: 1,
    rarity: 5,
    description: "Heal for %.",
    tags: ["benefit"],
    flavorText: "There's no way I could mess up a simple healing spell, right?",
    aliases:{ adj:"rejuvenative", verb:"heal", concept:"restoration", object:"salve", creature:"medic"}
  },
  {
    name: "add_health_opp",
    value: 1,
    rarity: 4,
    description: "Heal your opponent for %.",
    tags: ["drawback"],
    flavorText: "That was healing touch, not drain touch?",
    aliases:{ adj:"revitalizing", verb:"cure", concept:"benevolence", object:"bandage", creature:"cleric"}
  }
];

