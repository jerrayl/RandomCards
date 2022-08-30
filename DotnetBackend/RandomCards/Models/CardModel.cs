using System.Collections.Generic;

namespace RandomCards.Models
{
    public class CardModel
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int? SequenceNum { get; set; }
        public string FlavorText { get; set; }
        public string Image { get; set; }
        public List<CardModifierModel> Modifiers { get; set; }
    }

    public class CardModifierModel
    {
        public float Effect { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public float Rarity { get; set; }
        public string Description { get; set; }
    }
}