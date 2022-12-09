using ExyOS.Commands;
using ExyOS.UserDefinitions;
using System.IO;

namespace ExyOS {
    internal class Program {
        static void Main(string[] args) {
            ExyOs exy = new ExyOs();
            exy.MainLoop();
        }
    }
}