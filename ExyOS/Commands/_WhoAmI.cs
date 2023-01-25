using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    /// <summary>
    /// Displays current user ID and name
    /// </summary>
    [Description("whoami", "Displays current user ID and name")]
    internal class _WhoAmI : Command, ICommand {
        public void Execute(params string[]? args) {
            Console.WriteLine(ExyOs.user.ToString());

            if (args != null) {
                string type = args[0];
            }
        }
    }
}
