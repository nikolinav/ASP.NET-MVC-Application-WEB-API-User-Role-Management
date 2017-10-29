using Data.ClientConection;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MappController : Controller
    {

        [HttpPost]
        public JsonResult GetUsers()
        {
            var data1 = Users();
            return Json(data1, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<UserDetailsDTO> Users()
        {

            UserClient UC = new UserClient();

            return (from p in UC.findAll()
                    select new
                    {
                        Name = p.FirstName,
                        Address = p.Address,
                        City = p.City,
                        Id = p.Id
                    }).ToList()
                .Select(res => new UserDetailsDTO
                {
                    FirstName = res.Name,
                    Address = res.Address,
                    City = res.City,
                    Id = res.Id
                });

        }
    }
}