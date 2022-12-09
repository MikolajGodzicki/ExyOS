using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.UserDefinitions {
    /// <summary>
    /// Contains informations of selected User.
    /// </summary>
    internal class User {
        public Identifier ID { get; } = new Identifier();
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public List<Group> Groups { get; set; } = new List<Group>();

        public User() { }
        public User(string name, string password) {
            Name = name;
            Password = password;
        }

        public override string ToString() {
            return $"ID:{ID.Id} NAME:{Name}";
        }
    }
}
