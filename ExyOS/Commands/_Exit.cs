using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("exit (delay-to-exit)", "Exit from command prompt")]
    internal class _Exit : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args != null && args.Length == 1) {
                string delay_to_exit = args[0];
                
                return;
            }

            System.Environment.Exit(0);
        }
    }
}
