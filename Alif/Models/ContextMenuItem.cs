using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleContextMenuInDataGridRow
{
    public class ContextMenuItem : ReactiveObject
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        public ICommand Command { get; set; }
    }
}
