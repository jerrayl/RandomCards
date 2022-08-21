namespace RandomCards.Entities
{
    public class ClassTag : BaseEntity
    {
        public string ClassId { get; set; }
        public string TagId { get; set; }
        public string Rarity { get; set; }

        public virtual Class Class { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
