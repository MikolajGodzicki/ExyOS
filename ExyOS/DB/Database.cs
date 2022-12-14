using ExyOS.GroupDefinitions;
using ExyOS.UserDefinitions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.DB
{
    /// <summary>
    /// Contains user, group etc. informations
    /// </summary>
    internal class Database {
        public static List<User> users { get; private set; }
        public static List<Group> groups { get; private set; }
        public Database() {
            users = LoadUsers();
            groups = LoadGroups();
        }

        private List<User> LoadUsers() {
            string path = $"{ExyOs.GetDBDirectory()}\\users.json";
            string content = File.ReadAllText(path);

            List<User>? users_ = JsonConvert.DeserializeObject<List<User>>(content);

            if (users_ == null ) {
                return new List<User>();
            }
            
            return users_;
        }

        private List<Group> LoadGroups() {
            string path = $"{ExyOs.GetDBDirectory()}\\groups.json";
            string content = File.ReadAllText(path);

            List<Group>? groups_ = JsonConvert.DeserializeObject<List<Group>>(content);

            if (groups_ == null ) {
                return new List<Group>();
            }

            return groups_;
        }
    }
}
