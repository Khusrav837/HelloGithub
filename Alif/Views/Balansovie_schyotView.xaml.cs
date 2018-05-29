using Alif.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alif.Views
{
    /// <summary>
    /// Interaction logic for Balansovie_schyotView.xaml
    /// </summary>
    public partial class Balansovie_schyotView : UserControl, INavigatable
    {
        Balansovie_schyotViewModel _bsch;

        public Balansovie_schyotView()
        {
            InitializeComponent();
            _bsch = new Balansovie_schyotViewModel();
            DataContext = _bsch;
        }

        public string Title => "Балансовые счета";

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        => e.Column.Header = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName;
    }
}
