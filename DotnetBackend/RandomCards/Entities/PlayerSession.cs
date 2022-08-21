using System;
using System.Collections.Generic;

namespace RandomCards.Entities
{
    public class PlayerSession : BaseEntity
    {
        public int AccountId { get; set; }
        public int? GameRoomId { get; set; }
        public int PlayerNumber { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }

        public virtual Account Account { get; set; }
        public virtual GameRoom GameRoom { get; set; }
        public virtual List<AttributeValue> AttributeValues { get; set; }
        public virtual List<PlayerCard> PlayerCards { get; set; }
    }
}
