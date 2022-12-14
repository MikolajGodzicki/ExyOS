﻿using ExyOS.Commands;
using ExyOS.DB;
using ExyOS.FileManagement;
using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS {
    internal class ExyOs {
        private static ExyOs? instance = null;
        public static ExyOs Instance {
            get {
                if (instance == null) {
                    instance = new ExyOs();
                }
                return instance;
            }
        }

        private Lexer lexer;
        private Parser parser;

        private DefaultFiles defaultFiles;
        public Database database;

        public User user { get; private set; }
        private Authenticator authenticator;

        private CommandContainer commandContainer;

        public static string logicPath = "usr\\bin";
        public static string osPath = "";

        private string version = "0.13_beta";

        public ExyOs() {
            lexer = new Lexer();
            parser = new Parser();
            defaultFiles = new DefaultFiles();
            commandContainer = new CommandContainer();
            database = new Database();

            authenticator = new Authenticator();
            user = authenticator.Authenticate();

            string path = GetCurrentDirectoryName();
            defaultFiles.CreateFilesIfNotExist(path);
        }

        

        public void MainLoop() {
            DisplayLogo();
            while (true) {
                osPath = $"{GetCurrentDirectoryName()}\\root\\{logicPath}";
                DisplayConsole(user, logicPath);
                string? input = Console.ReadLine();
                Command command = lexer.InterpretInputToCommand(input);
                parser.Parse(command);

            }

        }

        public List<string> GetFiles()
                => Directory.EnumerateFiles(osPath)
                .ToList();

        public List<string> GetFilesNames() {
            List<string> files = GetFiles();
            List<string> names = new List<string>();

            foreach (string file in files) {
                names.Add(file.Split('\\').Last());
            }

            return names;
        }

        public List<string> GetDirectories()
                => Directory.EnumerateDirectories(osPath)
                .ToList();

        public List<string> GetDirectoriesNames() {
            List<string> directories = GetDirectories();
            List<string> names = new List<string>();

            foreach (string directory in directories) {
                names.Add(directory.Split('\\').Last());
            }

            return names;
        }

        private static void DisplayConsole(User user, string path) {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{user.ID.Id}_{user.Name}#{path} >>");
            Console.ResetColor();
            Console.Write(" ");
        }

        public static string GetCurrentDirectoryName() {
            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (path == null) {
                return String.Empty;
            }

            return path;
        }

        public static string GetDBDirectory() {
            return $"{GetCurrentDirectoryName()}\\root\\etc";
        }

        private void DisplayLogo() {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\r\n███████╗██╗░░██╗██╗░░░██╗░░░░░░░█████╗░░██████╗\r\n██╔════╝╚██╗██╔╝╚██╗░██╔╝░░░░░░██╔══██╗██╔════╝\r\n█████╗░░░╚███╔╝░░╚████╔╝░█████╗██║░░██║╚█████╗░\r\n██╔══╝░░░██╔██╗░░░╚██╔╝░░╚════╝██║░░██║░╚═══██╗\r\n███████╗██╔╝╚██╗░░░██║░░░░░░░░░╚█████╔╝██████╔╝\r\n╚══════╝╚═╝░░╚═╝░░░╚═╝░░░░░░░░░░╚════╝░╚═════╝░");
            Console.ResetColor();
            Console.WriteLine($"Current Version: {version}");
        }
    }
}
