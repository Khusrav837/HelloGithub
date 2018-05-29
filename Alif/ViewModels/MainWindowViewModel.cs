namespace Alif.ViewModels
{

    using System.Windows.Input;
    using System;
    using System.ComponentModel;
    using Alif.Models;
    using ReactiveUI;
    using Alif.Views;
    using System.Collections.ObjectModel;

    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            CreateDefaultsMenu();
        }

        void CreateDefaultsMenu()
        {
            menuItems = new ObservableCollection<MenuItem>();
            menuItems.Add(new MenuItem("СПРАВОЧНИК")
            {
                Page = new Views.MenuItem2Control(), Status = 1,

                Childs = new ObservableCollection<MenuItem>()
                {
                     new MenuItem("Балансовые счета"){ Page=new Views.Balansovie_schyotView(), Status=2},
                    new MenuItem("Установка курса-по умолчанию"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Установка курса-по сервису"){ Page=new Views.MenuItem2Control(), Status=2},
                }
            });
            menuItems.Add(new MenuItem("КЛИЕНТЫ")
            {
                Page = new Views.MenuItem2Control(), Status = 1,

                Childs = new ObservableCollection<MenuItem>()
                {
                     new MenuItem("Клиент"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Редактирование Клиента"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Лицевой счет"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Редактирования лицевого счета"){ Page=new Views.MenuItem2Control(), Status=2},
                }
            });
            menuItems.Add(new MenuItem("КАССА")
            {
                Page = new Views.MenuItem2Control(), Status = 1,

                Childs = new ObservableCollection<MenuItem>()
                {
                     new MenuItem("Приход от Дилера"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Расход Дилеру"){ Page=new Views.MenuItem2Control(), Status=2},
                }
            });
            menuItems.Add(new MenuItem("БАНК")
            {
                Page = new Views.MenuItem2Control(), Status = 1,

                Childs = new ObservableCollection<MenuItem>()
                {
                     new MenuItem("Приход от Дилера"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Расход Дилеру"){ Page=new Views.MenuItem2Control(), Status=2},
                }
            });
            menuItems.Add(new MenuItem("ОПЕРАЦИИ")
            {
                Page = new Views.MenuItem2Control(), Status = 1,

                Childs = new ObservableCollection<MenuItem>()
                {
                     new MenuItem("Новая проводка"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Установка овердрафта"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Редактирование платежа"){ Page=new Views.MenuItem2Control(), Status=2},
                }

            });
            menuItems.Add(new MenuItem("ОТЧЕТЫ")
            {
                Page = new Views.MenuItem2Control(), Status = 1,

                Childs = new ObservableCollection<MenuItem>()
                {
                     new MenuItem("Платежи"){ Page=new Views.MenuItem2Control(), Status=2},
                    new MenuItem("Выписка по лицевому счету"){ Page=new Views.MenuItem2Control(), Status=2},
                }
            });
        }

        private ObservableCollection<MenuItem> menuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return menuItems; }
            set { menuItems = value; }
        }


        public static User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set => this.RaiseAndSetIfChanged(ref _currentUser, value);
        }

        INavigatable _currentPage;
        public INavigatable CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
    }
}
