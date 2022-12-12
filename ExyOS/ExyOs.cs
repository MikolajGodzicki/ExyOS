﻿using ExyOS.Commands;
using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS {
    internal class ExyOs {
        private static ExyOs? instance = null;

        private Lexer lexer;
        private Parser parser;

        public User user { get; private set; }
        private Authenticator authenticator;

        private CommandContainer commandContainer;

        public static string logicPath = "usr\\bin";
        public static string osPath = "";

        public ExyOs() {
            lexer = new Lexer();
            parser = new Parser();
            commandContainer = new CommandContainer();
            authenticator = new Authenticator();
            user = authenticator.Authenticate();
        }

        public static ExyOs Instance {
            get {
                if (instance == null) {
                    instance = new ExyOs();
                }
                return instance;
            }
        }

        public void MainLoop() {
            while (true) {
                osPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\root\\{logicPath}";
                DisplayConsole(user, logicPath);
                string? input = Console.ReadLine();
                Command command = lexer.InterpretInputToCommand(input);
                parser.Parse(command);
            }

        }

        private static void DisplayConsole(User user, string path) {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{user.ID.Id}_{user.Name}#{path} >>");
            Console.ResetColor();
            Console.Write(" ");
        }
    }
}
