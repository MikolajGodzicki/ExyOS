﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.Commands {
    internal interface ICommand {
        public void Execute(params string[]? args);
    }
}
