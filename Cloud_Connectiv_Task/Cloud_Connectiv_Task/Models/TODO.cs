using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cloud_Connectiv_Task.Models
{
    public class TODO
    {
        [Key]
        public int ID { get; set; } 
        [MaxLength(50, ErrorMessage ="Maximum length '50'")]
        public string NAME { get; set; }
        [MaxLength(500, ErrorMessage = "Maximum length '500'")]
        public string DESCRIPTION { get; set; }


    }
}