using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands
{
    /// <summary>
    /// Interface that implement execute method
    /// </summary>
    internal interface ICommand {
        /// <summary>
        /// Method to execute command
        /// </summary>
        public void Execute(params string[]? args);
    }
}
