using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.TextEditor.Interface {
    internal class Button : IInterfaceElement {

        private event Action OnClick;
        public string Text { get; set; } = String.Empty;
        private bool IsActive;

        public Button(string text, Action action) {
            Text = text;
            this.OnClick = action;
        }

        public void SetActive(bool isActive) {
            IsActive = isActive;
        }

        public void Render() {
            if (IsActive) {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write($"[ {Text} ]");

            if (IsActive) {
                Console.ResetColor();
            }
        }

        public void SetOnClick(Action action) {
            OnClick = action;
        }

        public void Execute() {
            OnClick.Invoke();
        }
    }
}
