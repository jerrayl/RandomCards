using System.Collections.Generic;

namespace RandomCards.Entities
{
    public class Deck : BaseEntity
    {
        public int ClassId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }

        public virtual List<Card> Cards { get; set; }
        public virtual Account Account { get; set; }
        public virtual Class Class { get; set; }
    }
}
