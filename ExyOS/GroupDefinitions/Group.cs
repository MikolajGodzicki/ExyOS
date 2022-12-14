using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.GroupDefinitions
{
    /// <summary>
    /// Class contains unique ID and name.
    /// </summary>
    [Serializable]
    internal class Group
    {
        public GroupIdentifier ID { get; } = new GroupIdentifier();
        public string Name { get; private set; } = string.Empty;

        public Group() { }
        public Group(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"ID:{ID.Id} GROUP_NAME:{Name}";
        }
    }
}
