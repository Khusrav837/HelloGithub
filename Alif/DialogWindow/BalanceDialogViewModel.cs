using Alif.Connection;
using Alif.Helpers;
using Alif.Models;
using Alif.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;

namespace Alif.DialogWindow
{
    public struct Backup
    {
        public int _BallnceAccount { get; set; }
        public string _name { get; set; }
        public bool _active { get; set; }
    }

    public class BalanceDialogViewModel : Balansovie_schyotViewModel
    {
        public BalanceDialogViewModel(Balansovie_schyotModel info)
        {
            BalanceInfo = info;

            _backup._BallnceAccount = info.BallnceAccount;
            _backup._name = info.Name;
            _backup._active = info.Active;

            Save = ReactiveCommand.Create(() =>
            {
                 _backup._BallnceAccount = info.BallnceAccount;
                 _backup._name = info.Name;
                 _backup._active = info.Active;

                App.Current.Windows.Cast<Window>().Where(win => win is BalanceEditDialog).FirstOrDefault().Close();

                
                IContext con = new Context();

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement request = xmlDoc.CreateElement("request");
                XmlElement q = xmlDoc.CreateElement("q");
                q.InnerText = "103";
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
                sign.InnerText = MD5Hash.CalculateMD5Hash(103 + MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber() + SerialNumber.GpuSerialNumber()) + MainWindowViewModel._currentUser.Password);
                request.AppendChild(sign);
                XmlElement sifr = xmlDoc.CreateElement("sifr");
                sifr.InnerText = BalanceInfo.BallnceAccount.ToString();
                request.AppendChild(sifr);
                XmlElement name = xmlDoc.CreateElement("name");
                name.InnerText = BalanceInfo.Name;
                request.AppendChild(name);
                XmlElement vid = xmlDoc.CreateElement("vid");
                vid.InnerText = BalanceInfo.Active.ToString();
                request.AppendChild(vid);
                xmlDoc.AppendChild(request);

                con.SendMessage(xmlDoc);
                
            });

            Cancel = ReactiveCommand.Create(()=> {

                BalanceInfo.BallnceAccount = _backup._BallnceAccount;
                BalanceInfo.Name = _backup._name;
                BalanceInfo.Active = _backup._active;
                App.Current.Windows.Cast<Window>().Where(win => win is BalanceEditDialog).FirstOrDefault().Close();
            });

        }

        public BalanceDialogViewModel()
        {
            Save = ReactiveCommand.Create(()=> {

                Hamroh();

            });
        }

        Balansovie_schyotModel _balanceInfo;

        public Balansovie_schyotModel BalanceInfo
        {
            get { return _balanceInfo; }
            set { _balanceInfo = value; OnPropertyChanged(); }
        }

        Balansovie_schyotModel _AddBalance = new Balansovie_schyotModel();

        public Balansovie_schyotModel AddBalance
        {
            get { return _AddBalance; }
            set { _AddBalance = value; OnPropertyChanged(); }
        }

        public Backup _backup;

        public ICommand Save { get; set; }

        public ICommand Cancel { get; set; }
    }
}
