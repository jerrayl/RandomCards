namespace RandomCards.Entities
{
    public class CardModifier : BaseEntity
    {
        public int CardId { get; set; }
        public int ModifierId { get; set; }
        public float Effect { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Modifier Modifier { get; set; }
    }
}
