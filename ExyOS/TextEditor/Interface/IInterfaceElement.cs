﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExyOS.TextEditor.Interface {
    internal interface IInterfaceElement {
        public string Text { get; set; }
        public void Render();
    }
}
