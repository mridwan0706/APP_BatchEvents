using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_BatchEventsAPI.Models
{
    [Table("TB_M_Employee")]
    public class EmployeeVM
    {
        public string Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birth_date { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection <EventVM>Events { get; set; }
        public virtual ICollection<LoginVM> Logins { get; set; }        
    }
}