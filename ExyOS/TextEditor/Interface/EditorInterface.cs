using ExyOS.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.TextEditor.Interface {
    internal class EditorInterface {
        private Button[] buttons;

        public int SelectedButton = 0;
        private int memSelectedButton = 0;

        enum EditorMode {
            None,
            Command,
            Edit
        }

        private EditorMode mode = EditorMode.Command;

        public EditorInterface() {
            buttons = new Button[5] {
                new Button("Save [F1]", EmptyAction),
                new Button("Open [F2]", EmptyAction),
                new Button("Copy [F3]", EmptyAction),
                new Button("Paste [F4]", EmptyAction),
                new Button("Exit [F5]", ButtonExit)
            };


            UpdateButton();
        }

        private void RenderUI() {
            new _Clear().Execute(null);

            foreach (IInterfaceElement button in buttons) {
                button.Render();
            }

            Console.Write($"\nUse [F9] to change mode | Current Mode: {mode}\n");
            
        }

        private void EmptyAction() { }

        private void ButtonExit() => ExyOs.IsTextEditorOpened = false;

        public void ExecuteCurrentButton() => buttons[SelectedButton].Execute();

        public void UpdateButton() {
            if (SelectedButton < 0 || SelectedButton > buttons.Length - 1) {
                return;
            }

            buttons[memSelectedButton].SetActive(false);
            memSelectedButton = SelectedButton;
            buttons[SelectedButton].SetActive(true);
            RenderUI();
        }

        public void ChangeButton(int index) => SelectedButton = index;

        public void ChangeMode() => mode = mode == EditorMode.Command ? EditorMode.Edit : EditorMode.Command;
    }
}
