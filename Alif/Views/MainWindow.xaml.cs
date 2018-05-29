using Alif.Models;
using Alif.ViewModels;
using System.Windows;

namespace Alif.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void ContentControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var menuItem = e.NewValue as MenuItem;
            if (menuItem == null)
            {
                return;
            }
            _viewModel.CurrentPage = menuItem.Page;
        }
    }
}
