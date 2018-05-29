using Alif.Services;
using Alif.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Alif
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        LoginViewModel _viewModel;
        public LoginWindow()
        {
            InitializeComponent();

            _viewModel = new LoginViewModel(new AuthenticationService());
            DataContext = _viewModel;
        }
    }
}
