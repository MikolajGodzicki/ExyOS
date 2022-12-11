using ExyOS.UserDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Database {
    /// <summary>
    /// Contains user, group etc. informations
    /// </summary>
    internal class Database {
        public List<User> users;
        public List<Group> groups;
        public Database() {
            users = new List<User>();
            groups = new List<Group>();
        }
    }
}
