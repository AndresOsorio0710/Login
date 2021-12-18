using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Login
    {
        public Guid LoginId { get; set; }
        public Guid UserId { get; set; }
        public string UserKey { get; set; }
        public string Password { get; set; }
        public DateTime DateIn { get; set; }
        public User User { get; set; }
    }
}