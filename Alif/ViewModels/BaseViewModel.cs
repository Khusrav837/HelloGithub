using Alif.Connection;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alif.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        public IContext Context { get; set; }

    }
}
