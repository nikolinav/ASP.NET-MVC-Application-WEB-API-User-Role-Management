using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using Service.Interface;

namespace Service.Repository
{
    public class FileRepository : IDisposable, IFileRepository
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

        public File GetById(int id)
        {
        
                return db.Files.FirstOrDefault(p => p.FileId == id);
            
        }

        public void Delete(File file)
        {
            db.Files.Remove(file);
            db.SaveChanges();
        }
    }
}
