using System.Collections.Generic;

namespace RandomCards.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UniqueAbility { get; set; }

        public virtual List<ClassTag> ClassTags { get; set; }
    }
}
