using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {

    [Description("cat [file-name]", "Display file content")]
    internal class _Cat : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args != null && args.Length == 1) {
                string file_name = args[0];

                List<string> names = ExyOs.Instance.GetFilesNames();
                if (!names.Contains(file_name)) {
                    Console.WriteLine($"There is no file with \"{file_name}\" name");
                    return;
                }

                string[] lines = File.ReadAllLines($"{ExyOs.osPath}\\{file_name}");

                DisplayLine(lines);
                return;
            }

            Console.WriteLine("Cat command needs one argument");
        }

        private void DisplayLine(string[] lines) {
            foreach (string line in lines) {
                Console.WriteLine(line);
            }
        }
    }
}
