using System.Collections.Generic;

namespace RandomCards.Entities
{
    public class GameRoom : BaseEntity
    {
        public string Identifier { get; set; }
        public Constants.GameStatus Status { get; set; }
        public int CurrentPlayerNumber { get; set; }

        public virtual List<PlayerSession> Players { get; set; }
    }
}
