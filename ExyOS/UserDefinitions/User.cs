using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExyOS.GroupDefinitions;

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
        public List<Group> Groups { get; set; }

        public User() { }
        public User(string name, string password) {
            ID = new UserIdentifier();
            Groups = new List<Group>();

            Name = name;
            Password = password;
        }

        public override string ToString() {
            return $"ID:{ID.Id} USER_NAME:{Name}";
        }
    }
}
