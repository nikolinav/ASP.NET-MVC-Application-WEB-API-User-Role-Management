using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Service.Interface;
using Data.Model;

namespace Service.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {

        public ApplicationDbContext db = new ApplicationDbContext();


        public void Add(UserAccount account)
        {
            db.UserAccount.Add(account);
            db.SaveChanges();
        }

        public UserAccount GetByUserAccount(UserAccount userAccount)
        {
            UserAccount user = db.UserAccount.FirstOrDefault(p => p.Username == userAccount.Username && p.Password == userAccount.Password);
            return user;
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool CheckLogin(string username, string password)
        {
            var user = db.UserAccount.FirstOrDefault(c => c.Username == username && c.Password == password);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool Logout()
        {
            return true;
        }

    }
}
