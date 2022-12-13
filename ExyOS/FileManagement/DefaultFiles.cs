using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.FileManagement {
    internal class DefaultFiles {
        public void CreateFilesIfNotExist(string path) {
            //directories
            CreateDirectory($"{path}\\root");
            CreateDirectory($"{path}\\root\\usr");
            CreateDirectory($"{path}\\root\\usr\\bin");
            CreateDirectory($"{path}\\root\\etc");

            //files
            CreateFile($"{path}\\root\\etc\\users.exy");
            CreateFile($"{path}\\root\\etc\\groups.exy");
        }

        private void CreateDirectory(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }

        private void CreateFile(string path) {
            if (!File.Exists(path)) {
                File.Create(path);
            }
        }
    }
}
