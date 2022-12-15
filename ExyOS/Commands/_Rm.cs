using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("rm [file-name]", "Remove specified file")]
    internal class _Rm : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args != null && args.Length == 1) {
                string file_name = args[0];

                File.Delete($"{ExyOs.osPath}\\{file_name}");
            }
        }
    }
}
