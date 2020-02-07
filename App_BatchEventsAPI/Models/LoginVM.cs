using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_BatchEventsAPI.Models
{
    [Table("TB_M_Login")]
    public class LoginVM
    {
        [Key]
        public string Email { get; set; }
        public string password { get; set; }
        public virtual ICollection<LoginVM> Roles { get; set; }
    }
}