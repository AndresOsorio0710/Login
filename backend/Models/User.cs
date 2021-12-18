using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace backend.Models
{
    public class User
    {
        [Key, Column("id"), JsonProperty("id")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "User name required."), Column("userName"), JsonProperty("userName"), StringLength(50, ErrorMessage = "The User name cannot more than 50 characteres.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User email required."), Column("userEmail"), JsonProperty("userEmail"), StringLength(100, ErrorMessage = "The User email cannot more than 100 characteres.")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "User password required."), Column("userPassword"), JsonProperty("userPassword"), StringLength(50, ErrorMessage = "The User password cannot more than 50 characteres.")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "User role required."), Column("userRole"), JsonProperty("userRole"), StringLength(2, ErrorMessage = "The User role cannot more than 2 characteres.")]
        public string UserRole { get; set; }
        public List<Login> Logins { get; set; }
    }
}