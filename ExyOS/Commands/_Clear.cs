using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    /// <summary>
    /// Clears console display
    /// </summary>
    [Description("clear", "Clears console display.")]
    internal class _Clear : Command, ICommand {
        public void Execute(params string[]? args) {
            Console.Clear();
        }
    }
}
