using Data.Model;
using Service.Interface;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UsersRoleController : ApiController
    {
        IRepository<UsersRole> _repository;

        public UsersRoleController(IRepository<UsersRole> repository)
        {
            _repository = repository;
        }

        public UsersRoleController()
        {

        }

        public IQueryable<UsersRole> GetUserRole()
        {
            return ((UsersRoleRepository)_repository).GetAll().AsQueryable();
        }

        [ResponseType(typeof(UsersRole))]
        public IHttpActionResult GetUsersRole(int id)
        {
            UsersRole usersRole = _repository.GetById(id);
            if (usersRole == null)
            {
                return NotFound();
            }

            return Ok(usersRole);
        }

        [ResponseType(typeof(UsersRole))]
        public IHttpActionResult PostUsersRole(UsersRole usersRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(usersRole);


            return CreatedAtRoute("DefaultApi", new { id = usersRole.Id }, usersRole);
        }

        [ResponseType(typeof(UsersRole))]
        public IHttpActionResult PutUsersRole(int id, UsersRole usersRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersRole.Id)
            {
                return BadRequest();
            }

            _repository.Update(usersRole);
            return Ok(usersRole);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUsersRole(int id)
        {
            UsersRole usersRole = _repository.GetById(id);
            if (usersRole == null)
            {
                return NotFound();
            }

            _repository.Delete(usersRole);

            return Ok();
        }
    }
}