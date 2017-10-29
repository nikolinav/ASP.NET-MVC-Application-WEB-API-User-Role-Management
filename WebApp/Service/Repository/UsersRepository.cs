using Data.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class UsersRepository : IDisposable, IRepository<User>
    {
        public ApplicationDbContext db = new ApplicationDbContext();

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

        public IEnumerable<User> GetAll()
        {
            return db.Userss.Include(p => p.UsersRole).Include(f => f.FilePath).ToList();
        }

        public User GetById(int id)
        {
            return db.Userss.Include(p => p.UsersRole).Include(s => s.FilePath).FirstOrDefault(p => p.Id == id);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;

            db.SaveChanges();
        }
        public void Delete(User user)
        {
            db.Userss.Remove(user);
            db.SaveChanges();
        }

        public void Add(User user)
        {
            db.Userss.Add(user);
            db.SaveChanges();
        }


    }
}
