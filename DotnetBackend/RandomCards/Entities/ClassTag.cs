namespace RandomCards.Entities
{
    public class ClassTag : BaseEntity
    {
        public int ClassId { get; set; }
        public int TagId { get; set; }
        public string Rarity { get; set; }

        public virtual Class Class { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
