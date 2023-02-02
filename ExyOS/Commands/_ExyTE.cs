using ExyOS.TextEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("exyTE", "Starts embedded text editor" +
        " | CTRL + S -> Save file" +
        " | CTRL + X -> Exit" +
        " | CTRL + Z -> Restore snapshot")]
    internal class _ExyTE : Command, ICommand {
        public void Execute(params string[]? args) {
            if (args == null || args.Length != 1) {
                Console.WriteLine("This command accept only one arg.");
                return;
            }

            new _Clear().Execute(null);

            ExyOs.IsTextEditorOpened = true;
            Editor editor = new Editor($"{ExyOs.osPath}\\{args[0]}");
            editor.Run();
        }
    }
}
