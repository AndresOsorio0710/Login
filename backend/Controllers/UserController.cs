using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Context;
using backend.Models;
using backend.Logic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoginContext loginContext;
        private LogicUser logicUser;
        public UserController(LoginContext _loginContext)
        {
            this.loginContext = _loginContext;
            this.logicUser = new LogicUser();
        }

        [HttpGet]
        public ActionResult Get()
        {
            //return await this.loginContext.Users.ToListAsync();
            var list = this.loginContext.Users.Select(user => new
            {
                id = user.UserId,
                userName = user.UserPassword,
                email = user.UserEmail,
                role = user.UserRole
            });
            return Ok(list);
        }

        [HttpGet("{_id}")]
        public ActionResult Get(Guid _id)
        {
            var user = this.loginContext.Users.Where(user => user.UserId == _id).Select(user => new
            {
                id = user.UserId,
                userName = user.UserPassword,
                email = user.UserEmail,
                role = user.UserRole
            }); 
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User _user)
        {
            string response = this.Validate(_user);
            if (response.Equals("Ok"))
            {
                response = this.logicUser.VlidatePassword(_user.UserPassword);
                if (response.Equals("Ok"))
                {
                    _user.UserId = Guid.NewGuid();
                    if (!_user.UserRole.Equals("SA") && !_user.UserRole.Equals("US"))
                        _user.UserRole = "US";
                    _user.UserPassword = this.logicUser.GetMD5(_user.UserPassword);
                    this.loginContext.Users.Add(_user);
                    await this.loginContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = _user.UserId }, _user);
                }
                else
                {
                    return Ok(response);
                }
            }
            else
            {
                return Ok(response);
            }
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