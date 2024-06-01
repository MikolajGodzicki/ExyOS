using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.UserDefinitions.CheckAuthentication {
    internal class CheckedUser {
        public bool isValid;
        public uint ID;

        public CheckedUser(bool isValid, uint iD) {
            this.isValid = isValid;
            ID = iD;
        }
    }
}
