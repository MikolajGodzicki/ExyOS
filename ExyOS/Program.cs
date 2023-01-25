﻿using ExyOS.Commands;
using ExyOS.UserDefinitions;
using System.IO;
using System.Runtime.CompilerServices;

namespace ExyOS {
    internal class Program {
        static void Main(string[] args) {
            ExyOs exy = new ExyOs();
            Authenticator auth = new Authenticator();

            User user = auth.Authenticate();
            ExyOs.user = user;
            exy.MainLoop();
        }
    }
}