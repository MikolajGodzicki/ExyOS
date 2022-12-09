using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    /// <summary>
    /// Displays current user ID and name
    /// </summary>
    internal class _WhoAmI : ICommand {
        public void Execute() {
            Console.WriteLine(ExyOs.Instance.user.ToString());
        }
    }
}
