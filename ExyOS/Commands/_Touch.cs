using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("touch [file-name]", "Create file with selected name")]
    internal class _Touch : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args != null && args.Length == 1) {
                string file_name = args[0];

                List<string> names = ExyOs.Instance.GetFilesNames();
                if (names.Contains(file_name)) {
                    Console.WriteLine($"There is actually file with \"{file_name}\" name");
                    return;
                }

                File.Create($"{ExyOs.osPath}\\{file_name}").Dispose();
                return;
            }

            Console.WriteLine("Touch command needs one argument");
        }
    }
}
