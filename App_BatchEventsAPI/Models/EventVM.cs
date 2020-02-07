using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_BatchEventsAPI.Models
{
    [Table("TB_T_Event")]
    public class EventVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime Time_up { get; set; }
        public DateTime Date { get; set; }
        public string Lesson { get; set; }
        public virtual ICollection<RoomVM> Rooms { get; set; }
        public virtual ICollection<EmployeeVM> Employees { get; set; }
        public virtual ICollection<BatchVM> Batches { get; set; }

    }
}