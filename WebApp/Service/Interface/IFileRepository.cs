using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Service.Interface
{
    public interface IFileRepository
    {

        File GetById(int id);
        void Delete(File file);

    }
}
