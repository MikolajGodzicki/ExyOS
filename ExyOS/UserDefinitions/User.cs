using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.UserDefinitions
{
    /// <summary>
    /// Contains informations of selected User.
    /// </summary>
    [Serializable]
    internal class User {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password) {
            Name = name;
            Password = password;
        }

        public User() { }

        public override string ToString() {
            return $"ID:{ID} USER_NAME:{Name}";
        }
    }
}
