using ExyOS.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.TextEditor.Interface
{
    internal class EditorInterface
    {
        private Button[] buttons;

        public int SelectedButton = 0;
        private int memSelectedButton = 0;

        public EditorInterface() {
            buttons = new Button[5] {
                new Button("Save [t]", EmptyAction),
                new Button("Open [y]", EmptyAction),
                new Button("Copy [c]", EmptyAction),
                new Button("Paste [v]", EmptyAction),
                new Button("Exit [esc]", ButtonExit)
            };


            UpdateButton();
        }

        private void RenderUI() {
            new _Clear().Execute(null);

            foreach (var button in buttons) {
                button.Render();
            }

            Console.Write(" |\n");
            foreach (var button in buttons) {
                for (int i = 0; i < button.Text.Length + 4; i++) {
                    Console.Write("_");
                }
            }

            Console.Write("_/");
            
        }

        private void EmptyAction() { }

        private void ButtonExit() {
            ExyOs.IsTextEditorOpened = false;
        }

        public void ExecuteCurrentButton() { 
            Debug.WriteLine(SelectedButton);
            buttons[SelectedButton].Execute();
        }

        public void UpdateButton() {
            if (SelectedButton < 0 || SelectedButton > buttons.Length - 1) {
                return;
            }

            buttons[memSelectedButton].SetActive(false);
            memSelectedButton = SelectedButton;
            buttons[SelectedButton].SetActive(true);
            RenderUI();
        }

        public void ChangeButton(int index) {
            if (index == -1 & SelectedButton == 0) {
                return;
            }

            if (index == 1 & SelectedButton == buttons.Length - 1) {
                return;
            }

            SelectedButton += index;
        }
    }
}
