using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("cd", "Change to selected directory")]
    internal class _Cd : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args == null || args.Length != 1) {
                Console.WriteLine("Cannot parse too many or too less arguments.");
                Console.WriteLine("This command accept only one arg.");
                return;
            }

            string pathToChange = args[0];

            if (pathToChange == "..") {
                string path = ExyOs.logicPath;
                List<string> list = path.Split('\\').ToList();

                list.RemoveAt(list.Count - 1);
                ExyOs.logicPath = string.Join('\\', list);

                return;
            }

            if (pathToChange == "/") {
                ExyOs.logicPath = "";
                return;
            }

            List<string> directories = ExyOs.Instance.GetDirectoriesNames();

            if (directories.Contains(pathToChange)) {
                ExyOs.logicPath += "\\" + pathToChange;
                return;
            }
        }
    }
}
