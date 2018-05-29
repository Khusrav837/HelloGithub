using Alif.Connection;
using Alif.DialogWindow;
using Alif.Helpers;
using Alif.Models;
using ReactiveUI;
using SampleContextMenuInDataGridRow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml;

namespace Alif.ViewModels
{
    public class Balansovie_schyotViewModel : EntityBase
    {

        private ObservableCollection<Balansovie_schyotModel> _bal;

        public ObservableCollection<Balansovie_schyotModel> Bal
        {
            get { return _bal; }
            set { _bal = value; OnPropertyChanged("Bal"); }
        }

       

        public ICommand EditBtn { get; set; }

        public ICommand DeleteBtn { get; set; }

        private Balansovie_schyotModel _SelectedItem;

        public Balansovie_schyotModel SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        ObservableCollection<ContextMenuItem> _contextMenuItems;
        public ObservableCollection<ContextMenuItem> ContextMenuItems
        {
            get => _contextMenuItems;
            set => _contextMenuItems = value;
        }

        public void Hamroh()
        {
            Bal.Add(new Balansovie_schyotModel { BallnceAccount = 111, Name = "Khusrav", Active = true });
            
            System.Windows.MessageBox.Show("Ok "+ Bal.Count().ToString());
        }

        public Balansovie_schyotViewModel()
        {
            _bal = new ObservableCollection<Balansovie_schyotModel>();
            _contextMenuItems = new ObservableCollection<ContextMenuItem>();
            var editContextMenuItem = new ContextMenuItem { Title = "Редактировать" };

            editContextMenuItem.Command = ReactiveCommand.CreateFromTask(async () =>
            {
                await App.Current.Dispatcher.BeginInvoke(new ThreadStart(() =>
                {
                    BalanceEditDialog customerEditWindow = new BalanceEditDialog
                    {
                        DataContext = new BalanceDialogViewModel(SelectedItem)
                    };

                    
                    customerEditWindow.ShowDialog();
                }));

            }, outputScheduler: RxApp.TaskpoolScheduler);

            var AddContextMenuItem = new ContextMenuItem { Title = "Добавить" };

            AddContextMenuItem.Command = ReactiveCommand.CreateFromTask(async () =>
            {
                await App.Current.Dispatcher.BeginInvoke(new ThreadStart(() =>
                {
                    BalanceAddDialog customerAddDialog = new BalanceAddDialog
                    {
                        DataContext = new BalanceDialogViewModel()
                    };
                    customerAddDialog.ShowDialog();
                }));

            }, outputScheduler: RxApp.TaskpoolScheduler);

            var deleteContextMenuItem = new ContextMenuItem { Title = "Удалить" };
            deleteContextMenuItem.Command = ReactiveCommand.Create(() =>
            {
                //TODO some stuff here
            }, outputScheduler: RxApp.TaskpoolScheduler);
            _contextMenuItems.Add(editContextMenuItem);
            _contextMenuItems.Add(AddContextMenuItem);
            _contextMenuItems.Add(deleteContextMenuItem);

            IContext con = new Context();
            string otvet;

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement request = xmlDoc.CreateElement("request");
            XmlElement q = xmlDoc.CreateElement("q");
            q.InnerText = "102";
            request.AppendChild(q);
            XmlElement token = xmlDoc.CreateElement("token");
            token.InnerText = MainWindowViewModel._currentUser.Token;
            request.AppendChild(token);
            XmlElement log = xmlDoc.CreateElement("login");
            log.InnerText = MainWindowViewModel._currentUser.Login;
            request.AppendChild(log);
            XmlElement pass = xmlDoc.CreateElement("pass");
            pass.InnerText = MainWindowViewModel._currentUser.Password;
            request.AppendChild(pass);
            XmlElement hard = xmlDoc.CreateElement("hard");
            hard.InnerText = MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber() + SerialNumber.GpuSerialNumber());
            request.AppendChild(hard);
            XmlElement sign = xmlDoc.CreateElement("sign");
            sign.InnerText = MD5Hash.CalculateMD5Hash(102 + MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber() + SerialNumber.GpuSerialNumber()) + MainWindowViewModel._currentUser.Password);
            request.AppendChild(sign);
            xmlDoc.AppendChild(request);

            otvet = con.SendMessage(xmlDoc);

            xmlDoc.LoadXml(otvet);

            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes("/response");

            foreach (XmlNode node in nodes)
            {
                string result = node.SelectSingleNode("result").InnerText;

                if (result == "1")
                {

                    XmlNodeList nodesSchyot = xmlDoc.DocumentElement.SelectNodes("/response/schyot");
                    foreach (XmlNode nodeSchyot in nodesSchyot)
                    {
                        Bal.Add(new Balansovie_schyotModel { BallnceAccount = int.Parse(nodeSchyot.SelectSingleNode("sifr").InnerText), Name = nodeSchyot.SelectSingleNode("name").InnerText, Active = bool.Parse(nodeSchyot.SelectSingleNode("vid").InnerText) });
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Ошибка резултат !!!");
                }
            }
            
        }
    }

    public class ConverterActive : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case true: return "Актив";
                case false: return "Пассив";
            }            

            return "Не известно";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
