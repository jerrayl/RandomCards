namespace RandomCards.Entities
{
    public class AttributeValue : BaseEntity
    {
        public int PlayerSessionId { get; set; }
        public int AttributeId { get; set; }
        public int Value { get; set; }

        public virtual Attribute Attribute { get; set; }
    }
}
