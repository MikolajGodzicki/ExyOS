using ExyOS.UserDefinitions.CheckAuthentication;
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

            List<User>? users_ = JsonConvert.DeserializeObject<List<User>>(content);
            users = users_ != null ? users_ : new List<User>();
        }

        public CheckedUser CheckIfUserIsValid(User user) {
            foreach (User _user in users) {
                if (_user.Name == user.Name &&
                    _user.Password == user.Password) {
                    return new CheckedUser(true, _user.ID);
                }
            }

            return new CheckedUser(false, 0);
        }
    }
}
