using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using AutoMapper;
using Data.Model;
using Service.Interface;

namespace WebApp.Controllers
{
    public class FileController : ApiController
    {

        public IFileRepository _repository;

        public FileController(IFileRepository repository)
        {
            _repository = repository;
        }

        [ResponseType(typeof(File))]
        public IHttpActionResult GetFile(int id)
        {
            File file = _repository.GetById(id);
            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteFile(int id)
        {
            File file = _repository.GetById(id);
            if (file == null)
            {
                return NotFound();
            }

            _repository.Delete(file);

            return Ok();
        }

    }

}