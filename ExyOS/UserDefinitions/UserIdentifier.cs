using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.UserDefinitions {
    /// <summary>
    /// Defines unique identifer number for every entity
    /// </summary>
    [Serializable]
    internal class UserIdentifier {
        public static int _id { get; private set; } 
        public int Id { get; }

        public UserIdentifier() {
            Id = _id;
            _id++;
        }
    }
}
