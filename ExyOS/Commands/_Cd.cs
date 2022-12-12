using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("cd", "Change directory to [arg]")]
    internal class _Cd : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args == null || args.Length != 1) {
                Console.WriteLine("Cannot parse too many or too less arguments.");
                Console.WriteLine("This command accept only one arg.");
                return;
            }

            string pathToChange = args[0];

        }
    }
}
