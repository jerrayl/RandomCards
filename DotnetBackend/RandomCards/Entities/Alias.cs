namespace RandomCards.Entities
{
    public class Alias : BaseEntity
    {
        public int ModifierId { get; set; }
        public string Name { get; set; }
        public Constants.AliasCategories Category { get; set; }

        public virtual Modifier Modifier { get; set; }
    }
}
