﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Alif.Connection
{
    public interface IContext 
    {
        string _ipadress { get; set; }
        int _port { get; set; }

        string SendMessage(XmlDocument message);
    }
}
