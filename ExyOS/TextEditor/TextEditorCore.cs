using ExyOS.Commands;
using ExyOS.TextEditor.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.TextEditor {
    internal class TextEditorCore {
        EditorInterface EditorInterface;
        InputHandler InputHandler;

        private string path = String.Empty;

        public TextEditorCore() {
            path = ExyOs.osPath;

            EditorInterface = new EditorInterface();
            InputHandler = new InputHandler();

            while (true) {
                if (!ExyOs.IsTextEditorOpened) {
                    new _Clear().Execute(null);
                    break;
                }

                EditorInterface.UpdateButton();

                ConsoleKey key = InputHandler.GetKey();
                switch (key) {
                    case ConsoleKey.LeftArrow:
                        EditorInterface.ChangeButton(-1);
                        break;

                    case ConsoleKey.RightArrow:
                        EditorInterface.ChangeButton(1);
                        break;

                    case ConsoleKey.Enter:
                        EditorInterface.ExecuteCurrentButton();
                        break;
                }
            }
        }
    }
}
