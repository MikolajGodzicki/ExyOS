using ExyOS.Commands;
using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExyOS {
    internal class Authenticator {
        public User Authenticate() {

            User user;

            string? input;
            string name, password;
            while (true) {
                Console.Write("Login: ");
                input = Console.ReadLine();
                name = input != null ? input : "";
                Console.Write("Password: ");
                input = Console.ReadLine();
                password = input != null ? input : "";

                user = new User(name, password);
                ValidUser validUser = UserContainer.Instance.CheckIfUserIsValid(user);
                if (validUser.isValid) {
                    user.ID = validUser.ID;
                    new _Clear().Execute(null);
                    break;
                }
            }

            return user;
        }
    }
}
