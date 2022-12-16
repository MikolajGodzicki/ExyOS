using ExyOS.TextEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    [Description("exyTE", "Starts embedded text editor")]
    internal class _ExyTE : Command, ICommand {
        public void Execute(params string[]? args) {
            new _Clear().Execute(null);

            ExyOs.IsTextEditorOpened = true;
            TextEditorCore textEditorCore = new TextEditorCore();
        }
    }
}
