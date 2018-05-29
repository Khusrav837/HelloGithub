using Alif.Connection;
using Alif.Helpers;
using Alif.Models;
using Alif.ViewModels;
using System;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Alif.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        //public static User AuthenUser;

        //public Task<Tuple<bool, User>> Login(string login, string password)
        //{

        //    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        //    {
        //        return Task.Factory.StartNew(() =>
        //        {
        //            return new Tuple<bool, User>(false, null);
        //        });
        //    }

        //    IContext con = new Context();
        //    string otvet;

        //    XmlDocument xmlDoc = new XmlDocument();
        //    XmlElement request = xmlDoc.CreateElement("request");
        //    XmlElement q = xmlDoc.CreateElement("q");
        //    q.InnerText = "101";
        //    request.AppendChild(q);
        //    XmlElement log = xmlDoc.CreateElement("login");
        //    log.InnerText = login;
        //    request.AppendChild(log);
        //    XmlElement pass = xmlDoc.CreateElement("pass");
        //    pass.InnerText = MD5Hash.CalculateMD5Hash(password);
        //    request.AppendChild(pass);
        //    XmlElement hard = xmlDoc.CreateElement("hard");
        //    hard.InnerText = MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber()+SerialNumber.GpuSerialNumber());
        //    request.AppendChild(hard);
        //    XmlElement sign = xmlDoc.CreateElement("sign");
        //    sign.InnerText = MD5Hash.CalculateMD5Hash(101+MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber() + SerialNumber.GpuSerialNumber())+MD5Hash.CalculateMD5Hash(password));
        //    request.AppendChild(sign);
        //    XmlElement soft = xmlDoc.CreateElement("soft");
        //    soft.InnerText = "07";
        //    request.AppendChild(soft);
        //    xmlDoc.AppendChild(request);

        //    otvet = con.SendMessage(xmlDoc);

        //    xmlDoc.LoadXml(otvet);

        //    XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes("/response");

        //    foreach (XmlNode node in nodes)
        //    {
        //        string result = node.SelectSingleNode("result").InnerText;

        //        if(result=="1")
        //        {

        //            return Task.Factory.StartNew(() =>
        //            {
        //                return new Tuple<bool, User>(true, new User { FullName = node.SelectSingleNode("uname").InnerText, Login = login, Password = MD5Hash.CalculateMD5Hash(password), Token= node.SelectSingleNode("token").InnerText });
        //            });
        //        }
        //        else
        //        {
        //            return Task.Factory.StartNew(() =>
        //            {
        //                return new Tuple<bool, User>(false, null);
        //            });
        //        }
        //    }


        //    return Task.Factory.StartNew(() =>
        //    {
        //        return new Tuple<bool, User>(false, null);
        //    });
        //}
        public bool Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {

                return false;
            }

            IContext con = new Context();
            string otvet;

            XmlDocument xmlDoc = new XmlDocument();
            XmlElement request = xmlDoc.CreateElement("request");
            XmlElement q = xmlDoc.CreateElement("q");
            q.InnerText = "101";
            request.AppendChild(q);
            XmlElement log = xmlDoc.CreateElement("login");
            log.InnerText = login;
            request.AppendChild(log);
            XmlElement pass = xmlDoc.CreateElement("pass");
            pass.InnerText = MD5Hash.CalculateMD5Hash(password);
            request.AppendChild(pass);
            XmlElement hard = xmlDoc.CreateElement("hard");
            hard.InnerText = MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber() + SerialNumber.GpuSerialNumber());
            request.AppendChild(hard);
            XmlElement sign = xmlDoc.CreateElement("sign");
            sign.InnerText = MD5Hash.CalculateMD5Hash(101 + MD5Hash.CalculateMD5Hash(SerialNumber.HddSerialNumber() + SerialNumber.GpuSerialNumber()) + MD5Hash.CalculateMD5Hash(password));
            request.AppendChild(sign);
            XmlElement soft = xmlDoc.CreateElement("soft");
            soft.InnerText = "07";
            request.AppendChild(soft);
            xmlDoc.AppendChild(request);

            otvet = con.SendMessage(xmlDoc);

            xmlDoc.LoadXml(otvet);

            XmlNodeList nodes = xmlDoc.DocumentElement.SelectNodes("/response");

            foreach (XmlNode node in nodes)
            {
                string result = node.SelectSingleNode("result").InnerText;

                if (result == "1")
                {
                    MainWindowViewModel._currentUser = new User { FullName = node.SelectSingleNode("uname").InnerText, Login = login, Password = MD5Hash.CalculateMD5Hash(password), Token = node.SelectSingleNode("token").InnerText };
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
