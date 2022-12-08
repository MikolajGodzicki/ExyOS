using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.UserDefinitions {
    /// <summary>
    /// Class contains IEnumarable? of all users, unique ID and name.
    /// </summary>
    internal class Group {
        public Identifier ID { get; } = new Identifier();
        public string Name { get; private set; } = String.Empty;
        public IEnumerable<User>? Users { get; set; }
    }
}
