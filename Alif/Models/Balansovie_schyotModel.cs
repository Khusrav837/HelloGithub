using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alif.Models
{
    public class Balansovie_schyotModel : EntityBase
    {
        private int _BalanceAccount;

        [DisplayName("Счет 2 значный цифровой")]
        public int BallnceAccount
        {
            get { return _BalanceAccount; }
            set { _BalanceAccount = value; OnPropertyChanged("BallnceAccount"); }
        }

        private string _name;

        [DisplayName("Название буквенный")]
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private bool _active;

        [DisplayName("Вид")]
        public bool Active
        {
            get { return _active; }
            set { _active = value; OnPropertyChanged("Active"); }
        }
    }
}
