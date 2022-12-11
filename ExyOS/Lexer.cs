using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExyOS.Commands;

namespace ExyOS {
    /// <summary>
    /// Interprets input and return the type and arguments of command.
    /// </summary>
    internal class Lexer {

        public Command InterpretInputToCommand(string? input) {
            Command command = new Command();

            if (input == null) {
                return command;
            }

            string[] splitedInput = input.Trim().Split(' ').ToArray();
            int splitedInputCount = splitedInput.Count();

            string commandType = splitedInput[0]; 
            if (splitedInputCount > 1 ) {
                string[] commandArgs = splitedInput.Skip(1).Take(splitedInputCount - 1).ToArray();
                command.commandArgs = commandArgs;
            }

            command.commandType = commandType;

            return command;
        }

    }
}
