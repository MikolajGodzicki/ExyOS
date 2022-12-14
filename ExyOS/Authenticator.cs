using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExyOS.DB;

namespace ExyOS {
    internal class Authenticator {
        public User Authenticate() {
            User? user_ = null;

            while (user_ == null) {
                Console.Write("Insert name of account: ");
                string name = Console.ReadLine();
                Console.Write("Insert password of account: ");
                string password = Console.ReadLine();

                user_ = Database.users
                    .FirstOrDefault(x => x.Name == name &&
                                         x.Password == password);

            }

            User user = new User(user_.Name, user_.Password);

            Console.WriteLine("Succesfuly logged in!");

            return user;
        }
    }
}
