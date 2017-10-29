using Data.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using System.Web.Http.Description;
using System.Web.Http;
using AutoMapper;
using System.Web.Http.Results;

namespace WebApp.Controllers
{
    public class UsersController : ApiController 
    {
        public IRepository<User> _repository;

        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IQueryable<UserDetailsDTO> GetUsers()
        {
            return _repository.GetAll().AsQueryable().ProjectTo<UserDetailsDTO>();
        }

        [ResponseType(typeof(UserDetailsDTO))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
        

            return Ok(Mapper.Map<UserDetailsDTO>(user));
        }

        [ResponseType(typeof(UserDetailsDTO))]
        public IHttpActionResult PostUser(UserDetailsDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = Mapper.Map<User>(userDTO);
            _repository.Add(user);


            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        [ResponseType(typeof(UserDetailsDTO))]
        public IHttpActionResult PutUser(int id, UserDetailsDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != userDTO.Id)
            {
                return BadRequest();
            }
            var user = Mapper.Map<User>(userDTO);
            _repository.Update(user);
            return Ok(user);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _repository.Delete(user);

            return Ok();
        }


    }
}