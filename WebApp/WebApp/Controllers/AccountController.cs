using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Model;
using Service.Interface;

namespace WebApp.Controllers
{
    public class AccountController : ApiController
    {
        public IUserAccountRepository _repository;

        public AccountController(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public AccountController()
        {
            
        }
        [HttpPost]
        [Route("api/postUserAccount")]
        [ResponseType(typeof(UserAccountDto))]
        public IHttpActionResult PostUserAccount(UserAccountDto userAccountDto)
        {
            var user = Mapper.Map<UserAccount>(userAccountDto);
            
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        [Route("api/postCheck")]
        [ResponseType(typeof(UserAccountDto))]
        public IHttpActionResult PostCheckAccount(UserAccountDto userAccountDto)
        {
            var result = _repository.CheckLogin(userAccountDto.Username, userAccountDto.Password);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        [ResponseType(typeof(UserAccount))]
        public IHttpActionResult PostRegister(UserAccount account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _repository.Add(account);


            return CreatedAtRoute("DefaultApi", new { id = account.UserId }, account);
        }

        
    }
}