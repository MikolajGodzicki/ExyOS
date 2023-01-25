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

            Loop();
        }

        private void Loop() {
            while (true) {
                if (!ExyOs.IsTextEditorOpened) {
                    new _Clear().Execute(null);
                    break;
                }

                EditorInterface.UpdateButton();

                ConsoleKey key = InputHandler.GetKey();
                switch (key) {
                    case ConsoleKey.F1:
                        EditorInterface.ChangeButton(0);
                        break;
                    case ConsoleKey.F2:
                        EditorInterface.ChangeButton(1);
                        break;
                    case ConsoleKey.F3:
                        EditorInterface.ChangeButton(2);
                        break;
                    case ConsoleKey.F4:
                        EditorInterface.ChangeButton(3);
                        break;
                    case ConsoleKey.F5:
                        EditorInterface.ChangeButton(4);
                        break;

                    case ConsoleKey.F9:
                        EditorInterface.ChangeMode();
                        break;

                    case ConsoleKey.Enter:
                        EditorInterface.ExecuteCurrentButton();
                        break;
                }
            }
        }
    }
}
