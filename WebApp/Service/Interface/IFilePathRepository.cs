﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IFilePathRepository
    {
        FilePath GetById(int id);
    }
}
