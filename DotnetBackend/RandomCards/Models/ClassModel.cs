using System.Collections.Generic;

namespace RandomCards.Models
{
    public class ClassModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UniqueAbility { get; set; }

        public List<string> Tags { get; set; }
    }
}