namespace Alif.Models
{

    using System;
    using System.ComponentModel;
    using System.Windows;

    public class User : EntityBase
    {
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(); }
        }

        //private int _id;

        //public int Id
        //{
        //    get { return _id; }
        //    set { _id = value; OnPropertyChanged(); }
        //}

        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        //int _status;

        //public int Status
        //{
        //    get { return _status; }
        //    set { _status = value; OnPropertyChanged(); }
        //}

        private string _token;
        
        public string Token
        {
            get { return _token; }
            set { _token = value; OnPropertyChanged(); }
        }
    }
}
