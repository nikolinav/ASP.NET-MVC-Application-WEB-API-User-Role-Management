using Data.ClientConection;
using Data.Model;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            UserClient UC = new UserClient();
            var viewModel = new List<UserDetailsDTO>();
            viewModel = UC.findAll();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UserDetailsDTO user, HttpPostedFileBase upload)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    //if (upload != null && upload.ContentLength > 0)
                    //{
                    //    var avatar = new File
                    //    {
                    //        FileName = System.IO.Path.GetFileName(upload.FileName),
                    //        FileType = FileType.Avatar,
                    //        ContentType = upload.ContentType
                    //    };
                    //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    //    {
                    //        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    //    }
                    //    user.Files = new List<File> { avatar };

                    //}

                   

                    if (upload != null && upload.ContentLength > 0)
                    {

                        string path = Server.MapPath("~/File/" + upload.FileName);
                        upload.SaveAs(path);

                        user.FilePath = new FilePath
                        {
                            //FileName = System.Web.Hosting.HostingEnvironment.MapPath("~/File/" + upload.FileName),
                            FileName = "File/" + System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Photo
                        };



                    }

                    UserClient UC = new UserClient();
                    UC.Create(user);
                    //UC.findPath();
                }
            }
            catch (RetryLimitExceededException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }



            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Instructor instructor = db.Instructors.Include(i => i.FilePaths).SingleOrDefault(i => i.ID == id);
            UserClient UC = new UserClient();
            UserDetailsDTO userDetails = UC.find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View("Details", userDetails);
        }

        public ActionResult Delete(int? id)
        {
            UserClient UC = new UserClient();
            UserDetailsDTO user = UC.find(id);
            UC.Delete(id);
            return View("Delete", user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            UserClient UC = new UserClient();
            UC.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id, HttpPostedFileBase upload)
        {
            UserClient UC = new UserClient();
            UserDetailsDTO user = UC.find(id);
            try
            {
                //if (upload != null && upload.ContentLength > 0)
                //{
                //    if (user.Files.Any(f => f.FileType == FileType.Avatar))
                //    {
                //        UC.DeleteFiles(id);
                //    }
                //    var avatar = new File
                //    {
                //        FileName = System.IO.Path.GetFileName(upload.FileName),
                //        FileType = FileType.Avatar,
                //        ContentType = upload.ContentType
                //    };
                //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                //    {
                //        avatar.Content = reader.ReadBytes(upload.ContentLength);
                //    }
                //    user.Files = new List<File> { avatar };
                //}

                if (upload != null && upload.ContentLength > 0)
                {
                    string path = Server.MapPath("~/File/" + upload.FileName);
                    upload.SaveAs(path);

                    if (upload != null && upload.ContentLength > 0)
                    {
                        user.FilePath = new FilePath
                        {
                            //FileName = System.Web.Hosting.HostingEnvironment.MapPath("~/File/" + upload.FileName),
                            FileName = "File/" + System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Photo
                        };
                    }
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            var clientIDs = UC.FindAllUsersRoles();

            
                var selectList = clientIDs.Select(x => new SelectListItem
            {
                Text = x.UserRoleName,
                Value = x.Id.ToString()
            });
            

            ViewBag.UserRoleId = selectList;


            return View("Edit", user);
        }

        [HttpPost]
        public ActionResult Edit(UserDetailsDTO user)
        {
            UserClient UC = new UserClient();
            UC.Edit(user);

            return RedirectToAction("Index");
        }


        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}