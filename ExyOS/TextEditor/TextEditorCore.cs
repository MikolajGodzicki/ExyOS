using ExyOS.Commands;
using ExyOS.TextEditor.Interface;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.TextEditor {
    class Editor {
        Buffer _buffer;
        Cursor _cursor;
        Stack<object> _history;
        string filePath = String.Empty;

        public Editor(string filePath) {
            this.filePath = filePath;
            var lines = File.ReadAllLines(this.filePath)
                            .Where(x => x != Environment.NewLine);

            _buffer = new Buffer(lines);
            _cursor = new Cursor();
            _history = new Stack<object>();
        }

        public void Run() {
            while (true) {
                if (!ExyOs.IsTextEditorOpened) {
                    new _Clear().Execute(null);
                    break;
                }

                Render();
                HandleInput();
            }
        }

        private void HandleInput() {
            var character = Console.ReadKey();

            if (character.Key == ConsoleKey.UpArrow) {
                _cursor = _cursor.Up(_buffer);
            }

            else if (character.Key == ConsoleKey.DownArrow) {
                _cursor = _cursor.Down(_buffer);
            }

            else if (character.Key == ConsoleKey.LeftArrow) {
                _cursor = _cursor.Left(_buffer);
            }

            else if (character.Key == ConsoleKey.RightArrow) {
                _cursor = _cursor.Right(_buffer);
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) == ConsoleModifiers.Control &&
                 character.Key == ConsoleKey.S) {
                SaveFile();
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) == ConsoleModifiers.Control &&
                 character.Key == ConsoleKey.X) {
                ExyOs.IsTextEditorOpened = false;
            }

            else if ((ConsoleModifiers.Control & character.Modifiers) == ConsoleModifiers.Control &&
                 character.Key == ConsoleKey.Z) {
                RestoreSnapshot();
            }

            else if (character.Key == ConsoleKey.Backspace) {
                if (_cursor.Col > 0) {
                    SaveSnapshot();
                    _buffer = _buffer.Delete(_cursor.Row, _cursor.Col - 1);
                    _cursor = _cursor.Left(_buffer);
                }
            }

            else if (character.Key == ConsoleKey.Enter) {
                SaveSnapshot();
                _buffer = _buffer.SplitLine(_cursor.Row, _cursor.Col);
                _cursor = _cursor.Down(_buffer).MoveToCol(0);
            }

            else if (IsTextChar(character)) {
                SaveSnapshot();
                _buffer = _buffer.Insert(character.KeyChar.ToString(), _cursor.Row, _cursor.Col);
                _cursor = _cursor.Right(_buffer);
            }
        }

        private bool IsTextChar(ConsoleKeyInfo character) {
            return !Char.IsControl(character.KeyChar);
        }

        private void Render() {
            ANSI.ClearScreen();
            ANSI.MoveCursor(0, 0);
            _buffer.Render();
            ANSI.MoveCursor(_cursor.Row, _cursor.Col);
        }

        private void SaveSnapshot() {
            _history.Push(_cursor);
            _history.Push(_buffer);
        }

        private void RestoreSnapshot() {
            if (_history.Count > 0) {
                _buffer = (Buffer)_history.Pop();
                _cursor = (Cursor)_history.Pop();
            }
        }

        private void SaveFile() {
            File.WriteAllText(this.filePath, string.Join('\n', _buffer._lines));
        }
    }

    class Buffer {
        public string[] _lines { get; private set; }

        public Buffer(IEnumerable<string> lines) {
            _lines = lines.ToArray();
        }

        public void Render() {
            foreach (var line in _lines) {
                Console.WriteLine(line);
            }
        }

        public int LineCount() {
            return _lines.Count();
        }

        public int LineLength(int row) {
            return _lines[row].Length;
        }

        internal Buffer Insert(string character, int row, int col) {
            var linesDeepCopy = _lines.Select(x => x).ToArray();
            linesDeepCopy[row] = linesDeepCopy[row].Insert(col, character);
            return new Buffer(linesDeepCopy);
        }

        internal Buffer Delete(int row, int col) {
            var linesDeepCopy = _lines.Select(x => x).ToArray();
            linesDeepCopy[row] = linesDeepCopy[row].Remove(col, 1);
            return new Buffer(linesDeepCopy);
        }

        internal Buffer SplitLine(int row, int col) {
            var linesDeepCopy = _lines.Select(x => x).ToList();

            var line = linesDeepCopy[row];

            var newLines = new[] { line.Substring(0, col), line.Substring(col, line.Length - line.Substring(0, col).Length) };

            linesDeepCopy[row] = newLines[0];
            linesDeepCopy.Insert(row + 1, newLines[1]);

            return new Buffer(linesDeepCopy);
        }
    }

    class Cursor {
        public int Row { get; set; }
        public int Col { get; set; }


        public Cursor(int row = 0, int col = 0) {
            Row = row;
            Col = col;
        }

        internal Cursor Up(Buffer buffer) {
            return new Cursor(Row - 1, Col).Clamp(buffer);
        }

        internal Cursor Down(Buffer buffer) {
            return new Cursor(Row + 1, Col).Clamp(buffer);
        }


        internal Cursor Left(Buffer buffer) {
            return new Cursor(Row, Col - 1).Clamp(buffer);
        }

        internal Cursor Right(Buffer buffer) {
            return new Cursor(Row, Col + 1).Clamp(buffer);
        }

        private Cursor Clamp(Buffer buffer) {
            Row = Math.Min(buffer.LineCount() - 1, Math.Max(Row, 0));
            Col = Math.Min(buffer.LineLength(Row), Math.Max(Col, 0));
            return new Cursor(Row, Col);
        }

        internal Cursor MoveToCol(int col) {
            return new Cursor(Row, col);
        }
    }

    class ANSI {
        public static void ClearScreen() {
            Console.Clear();
        }

        public static void MoveCursor(int row, int col) {
            Console.CursorTop = row;
            Console.CursorLeft = col;
        }
    }
}
