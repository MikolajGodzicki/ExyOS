using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExyOS {
    internal class Authenticator {
        public User Authenticate() {

            User user = new User("root", "root");

            return user;
        }
    }
}
