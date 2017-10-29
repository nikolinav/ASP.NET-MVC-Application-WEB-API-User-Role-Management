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

    public class UsersRoleRepository : IDisposable, IRepository<UsersRole>
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(UsersRole usersRole)
        {
            db.UsersRoles.Add(usersRole);
            db.SaveChanges();
        }

        public void Delete(UsersRole usersRole)
        {
            db.UsersRoles.Remove(usersRole);
            db.SaveChanges();
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

        public IEnumerable<UsersRole> GetAll()
        {
            return db.UsersRoles.ToList();
        }

        public UsersRole GetById(int id)
        {
            return db.UsersRoles.FirstOrDefault(p => p.Id == id);
        }

        public void Update(UsersRole usersRole)
        {
            db.Entry(usersRole).State = EntityState.Modified;

            db.SaveChanges();
        }
    }

}
