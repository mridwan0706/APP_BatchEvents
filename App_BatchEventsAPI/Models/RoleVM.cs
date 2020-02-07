using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_BatchEventsAPI.Models
{
    [Table("TB_M_Roles")]
    public class RoleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LoginVM> Logins { get; set; }
        
    }
}