using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS {
    internal class DescriptionAttribute : Attribute {
        public string Name { get; set; }
        public string Description { get; set; }

        public DescriptionAttribute(string name, string description) {
            Name = name;
            Description = description;
        }
    }
}
