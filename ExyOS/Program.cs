using ExyOS.Commands;
using ExyOS.UserDefinitions;
using System.IO;

namespace ExyOS {
    internal class Program {
        static void Main(string[] args) {
            User user = new User("root", "root");
            string path = "/usr/bin";
            
            while (true) {
                DisplayConsole(user, path);
                Console.ReadLine();
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