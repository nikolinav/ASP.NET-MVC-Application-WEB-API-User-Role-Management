using Data.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApp.Controllers
{
    public class FilePathController : ApiController
    {

        public IFilePathRepository _repository;

        public FilePathController(IFilePathRepository repository)
        {
            _repository = repository;
        }

        public FilePathController()
        {
        
        }
        [ResponseType(typeof(FilePath))]
        public IHttpActionResult GetFilePath(int id)
        {
            FilePath file = _repository.GetById(id);
            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }
    }
}
