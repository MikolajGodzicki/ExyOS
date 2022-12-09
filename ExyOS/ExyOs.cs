using ExyOS.Commands;
using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS {
    internal class ExyOs {
        private static ExyOs? instance = null;

        public User user { get; private set; }
        private Authenticator authenticator;

        public ExyOs() {
            authenticator = new Authenticator();
            user = authenticator.Authenticate();
        }

        public static ExyOs Instance {
            get {
                if (instance == null) {
                    instance = new ExyOs();
                }
                return instance;
            }
        }

        public void MainLoop() {
            string path = "/usr/bin";

            while (true) {
                DisplayConsole(user, path);
                Console.ReadLine();
                _WhoAmI s = new _WhoAmI();
                s.Execute();
            }

        }

        private static void DisplayConsole(User user, string path) {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{user.ID.Id}_{user.Name}#{path} >>");
            Console.ResetColor();
            Console.Write(" ");
        }
    }
}
