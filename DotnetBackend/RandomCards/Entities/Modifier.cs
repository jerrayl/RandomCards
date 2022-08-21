using System.Collections.Generic;

namespace RandomCards.Entities
{
    public class Modifier : BaseEntity
    {
        public int? AttributeId { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public float Rarity { get; set; }
        public string Description { get; set; }
        public string FlavorText { get; set; }
        public string Image { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual List<ModifierTag> ModifierTags { get; set; }
        public virtual List<Alias> Aliases { get; set; }
    }
}

