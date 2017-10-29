using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserAccountRepository
    {
        void Add (UserAccount account);
        UserAccount GetByUserAccount (UserAccount user);
        bool CheckLogin(string email, string password);
        bool Logout();
    }
}
