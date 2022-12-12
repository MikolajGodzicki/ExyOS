using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    internal class CommandContainer {
        public static Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
        
        public CommandContainer() {
            Initialize();
        }

        private void Initialize() {
            commands["whoami"] = new _WhoAmI();
            commands["clear"] = new _Clear();
            commands["cd"] = new _Cd();
            commands["ls"] = new _Ls();
            commands["help"] = new _Help();
        }
    }
}
