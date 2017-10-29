using Data.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Repository
{
    public class FilePathRepository : IDisposable, IFilePathRepository
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

        public FilePath GetById(int id)
        {

            return db.FilePaths.FirstOrDefault(p => p.FilePathId == id);

        }
    }
}
