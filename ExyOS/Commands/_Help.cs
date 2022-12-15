using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    /// <summary>
    /// Display all avaible commands
    /// </summary>
    internal class _Help : Command, ICommand {
        public void Execute(params string[]? args) {
            Console.WriteLine("[] -- needed arguments");
            Console.WriteLine("() -- optional arguments\n");
            foreach (Command command in CommandContainer.commands.Values) {
                DescriptionAttribute[] desc = GetDescAttributes(command);
                if (desc != null) {
                    foreach (DescriptionAttribute descAttribute in desc) {
                        Console.WriteLine($"{descAttribute.Name}: {descAttribute.Description}");
                    }
                }

            }
        }

        private DescriptionAttribute[] GetDescAttributes(Command command) {
            return command.GetType().GetCustomAttributes<DescriptionAttribute>().ToArray();
        }
    }
}
