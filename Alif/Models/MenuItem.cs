using Alif.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Alif.Models
{
    public class MenuItem : EntityBase
    {
        public MenuItem(string title)
        {
            Title = title;
            Childs = new ObservableCollection<MenuItem>();
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private INavigatable page;

        public INavigatable Page
        {
            get { return page; }
            set { page = value; OnPropertyChanged(); }
        }

        private MenuItem _parent;

        public MenuItem Parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MenuItem> _childs;

        public ObservableCollection<MenuItem> Childs
        {
            get { return _childs; }
            set { _childs = value; OnPropertyChanged(); }
        }

        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }


    }
}
