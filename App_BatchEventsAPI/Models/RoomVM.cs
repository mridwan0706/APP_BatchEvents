using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_BatchEventsAPI.Models
{
    [Table("TB_M_Room")]
    public class RoomVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EventVM> Events { get; set; }
    }
}