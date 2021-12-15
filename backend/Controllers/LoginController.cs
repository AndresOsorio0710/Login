using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Context;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginContext loginContext;
        public LoginController(LoginContext _loginContext)
        {
            this.loginContext = _loginContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await this.loginContext.Users.ToListAsync();
        }

        [HttpGet("{_id}")]
        public async Task<ActionResult<User>> Get(Guid _id)
        {
            try
            {
                var user = await this.loginContext.Users.FindAsync(_id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                return Ok("Not Result." + e);
            }

        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User _user)
        {
            string response = this.Validate(_user);
            if (response.Equals("Ok"))
            {
                _user.UserId = Guid.NewGuid();
                if (!_user.UserRole.Equals("SA") && !_user.UserRole.Equals("US"))
                {
                    _user.UserRole = "US";
                }
                this.loginContext.Users.Add(_user);
                await this.loginContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = _user.UserId }, _user);
            }
            else
            {
                return Ok(response);
            }
        }



        [HttpGet("{_user}/{_password}")]
        public ActionResult<List<User>> GatlogIn(string _user, string _password)
        {
            var users = this.loginContext.Users.Where(u => (u.UserName.Equals(_user) || u.UserEmail.Equals(_user)) && (u.UserPassword.Equals(_password))).ToList();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        private string Validate(User _user)
        {
            var user = this.loginContext.Users.Where(u => (u.UserName == _user.UserName || u.UserEmail == _user.UserEmail)).FirstOrDefault();
            if (user == null)
            {
                return "Ok";
            }
            else if (user.UserName == _user.UserName)
            {
                return "Username not availiable.";
            }
            else
            {
                return "User email not availiable.";
            }
        }
    }
}