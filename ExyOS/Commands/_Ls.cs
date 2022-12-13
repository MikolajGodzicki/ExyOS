using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("ls", "Display all files at current path")]
    internal class _Ls : Command, ICommand {
        public void Execute(params string[]? args) {
            List<string> directories = ExyOs.Instance.GetDirectories();
            List<string> files = ExyOs.Instance.GetFiles();

            WriteDirectories(directories);
            WriteFiles(files);
        }

        private void WriteDirectories(List<string> directories) {
            foreach (string directory in directories) {
                Console.WriteLine("d " + directory.Split('\\').Last());
            }
        }

        private void WriteFiles(List<string> files) {
            foreach (string file in files) {
                Console.WriteLine(file.Split('\\').Last());
            }
        }
    }
}
