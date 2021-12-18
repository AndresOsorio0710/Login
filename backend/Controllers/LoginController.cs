using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using backend.Context;
using backend.Models;
using backend.Logic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginContext loginContext;
        private LogicLogin logicLogin;
        public LoginController(LoginContext _loginContext)
        {
            this.loginContext = _loginContext;
            this.logicLogin = new LogicLogin();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> Get()
        {
            return await this.loginContext.Logins.ToListAsync();
        }

        [HttpGet("{_id}")]
        public async Task<ActionResult<IEnumerable<Login>>> Get(Guid _id)
        {
            try
            {
                var login = await this.loginContext.Logins.Where(l => l.UserId==_id).ToListAsync();
                if (login == null)
                {
                    return NotFound();
                }
                return Ok(login);
            }
            catch (Exception e)
            {
                return Ok("Not Result." + e);
            }

        }

        [HttpGet("{_user}/{_password}")]
        public ActionResult GetlogIn(string _user, string _password)
        {
            User u = this.loginContext.Users.Where(
                u => (u.UserName.Equals(_user) || u.UserEmail.Equals(_user))
                && (u.UserPassword.Equals(this.logicLogin.GetMD5(_password)))).FirstOrDefault();
            if (u == null)
            {
                return Ok("Not result.");
            }
            this.SaveLogin(u.UserId, _password);

            var user = new
            {
                id = u.UserId,
                userName = u.UserPassword,
                email = u.UserEmail,
                role = u.UserRole
            };
            return Ok(user);
        }

        private async void SaveLogin(Guid _userId, string _useKey)
        {
            var user = await this.loginContext.Users.FindAsync(_userId);
            Login login = new Login();
            login.LoginId = new Guid();
            login.UserId = user.UserId;
            login.UserKey = _useKey;
            login.Password = user.UserPassword;
            login.DateIn = new DateTime();
            login.User = user;
            this.loginContext.Logins.Add(login);
            await this.loginContext.SaveChangesAsync();
        }
    }
}