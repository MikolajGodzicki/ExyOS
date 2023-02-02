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
            string name = String.Empty, password = String.Empty;
            while (true) {
                Console.Write("Login: ");
                name = GetName();
                Console.Write("Password: ");
                password = GetPassword();
                
                user = new User(name, password);
                CheckUser checkUser = UserContainer.Instance.CheckIfUserIsValid(user);
                if (checkUser.isValid) {
                    user.ID = checkUser.ID;
                    new _Clear().Execute(null);
                    break;
                }
            }

            return user;
        }

        private string GetName() {
            string input = Console.ReadLine();
            return input != null ? input : "";
        }

        private string GetPassword() {
            string password = String.Empty;
            ConsoleKey key;

            do {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0) {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar)) {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();

            return password;
        }
    }
}
