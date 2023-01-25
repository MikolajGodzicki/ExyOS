using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExyOS.UserDefinitions {
    internal class UserContainer {
        private static UserContainer? instance = null;
        public static UserContainer Instance {
            get {
                if (instance == null) {
                    instance = new UserContainer();
                }
                return instance;
            }
        }

        public List<User> users;

        public UserContainer() {
            string content = File.ReadAllText($"{ExyOs.GetCurrentDirectoryName()}\\root\\etc\\users.json");
            UserList? users_ = JsonConvert.DeserializeObject<UserList>(content);
            users = users_ != null ? users_.Users : new List<User>();
        }

        public ValidUser CheckIfUserIsValid(User user) {
            foreach (User _user in users) {
                if (_user.Name == user.Name &&
                    _user.Password == user.Password) {
                    return new ValidUser(true, _user.ID);
                }
            }

            return new ValidUser(false, 0);
        }
    }

    internal class ValidUser {
        public bool isValid;
        public uint ID;

        public ValidUser(bool isValid, uint iD) {
            this.isValid = isValid;
            ID = iD;
        }
    }

    internal class UserList {
        public List<User> Users;
    }
}
