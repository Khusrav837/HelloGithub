using Alif.Services;
using Alif.Views;
using ReactiveUI;
using System.Windows;
using System.Windows.Input;

namespace Alif.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        IAuthenticationService _authenticationManager;
        public LoginViewModel(IAuthenticationService authenticationManager)
        {
            _authenticationManager = authenticationManager;
            InitCommands();
        }
        private void InitCommands()
        {
            Login = ReactiveCommand.Create(() =>
            {
                bool result = _authenticationManager.Login(Username, Password);
                if (result)
                {
                    var mainWindow = new MainWindow() { };
                    Application.Current.MainWindow.Close();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect login or password");
                }
            });
            Cancel = ReactiveCommand.Create(() =>
            {
                Application.Current.MainWindow.Close();
            });
        }

        public ICommand Login { get; set; }
        public ICommand Cancel { get; set; }
        string _email;
        public string Username
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

    }
}
