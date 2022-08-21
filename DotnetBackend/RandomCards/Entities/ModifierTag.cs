namespace RandomCards.Entities
{
    public class ModifierTag : BaseEntity
    {
        public int ModifierId { get; set; }
        public int TagId { get; set; }

        public virtual Modifier Modifier { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

