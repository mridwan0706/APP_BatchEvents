using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace App_BatchEventsAPI.Models
{
    [Table("TB_M_Batch")]
    public class BatchVM
    {
        public string Id { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public virtual ICollection<EventVM> Events { get; set; }
    }
}