using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interface;
using Data.ClientConection;
using Data.Model;

namespace MVC.Controllers
{
    public class FileController : Controller
    {

        public IFileRepository _repository;

        public FileController(IFileRepository repository)
        {
            _repository = repository;
        }

        public FileController()
        {

        }
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            UserClient UC = new UserClient();
            var fileToRetrieve = UC.FindFileDetailsDto(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }

        public ActionResult Delete(int? id)
        {
            UserClient UC = new UserClient();
            File file = UC.FindFileDetailsDto(id);
            UC.DeleteFiles(id);
            return View("Delete", file);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            UserClient UC = new UserClient();
            UC.DeleteFiles(id);
            return RedirectToAction("Index");
        }
    }
}