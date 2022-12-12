using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExyOS.Commands;

namespace ExyOS {
    /// <summary>
    /// Executes command interpreted by Lexer.
    /// </summary>
    internal class Parser {
        public void Parse(Command command) { 
            if (command.commandType != String.Empty) {
                if (!CommandContainer.commands.ContainsKey(command.commandType)) {
                    Console.WriteLine($"[{command.commandType}]: There is no command of this type. \nwrite 'help' to get list of commands");
                    return;
                }

                CommandContainer.commands[command.commandType].Execute(command.commandArgs);
            }
        } 
    }
}
