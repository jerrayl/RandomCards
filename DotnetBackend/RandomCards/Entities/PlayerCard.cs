using System;

namespace RandomCards.Entities
{
    public class PlayerCard : BaseEntity
    {
        public int PlayerSessionId { get; set; }
        public int CardId { get; set; }
        public Constants.Locations Location { get; set; }

        public virtual PlayerSession PlayerSession { get; set; }
        public virtual Card Card { get; set; }
    }
}
