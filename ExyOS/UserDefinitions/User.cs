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
        public UserIdentifier ID { get; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password) {
            ID = new UserIdentifier();

            Name = name;
            Password = password;
        }

        public override string ToString() {
            return $"ID:{ID.Id} USER_NAME:{Name}";
        }
    }
}
