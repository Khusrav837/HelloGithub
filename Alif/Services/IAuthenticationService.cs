using Alif.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alif.Services
{
    public interface IAuthenticationService
    {
        //Task<Tuple<bool, User>> Login(string login, string password);

        bool Login(string login, string password);

    }
}
