using System.Collections.Generic;

namespace RandomCards.Entities
{
    public class Card : BaseEntity
    {
        public int DeckId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }

        public virtual List<CardModifier> Modifiers { get; set; }
        public virtual Deck Deck { get; set; }
    }
}
