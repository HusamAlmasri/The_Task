using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cloud_Connectiv_Task.Models
{
    public class Logging
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum length '50'")]
        public string NAME { get; set; }
        [MaxLength(500, ErrorMessage = "Maximum length '500'")]
        public string DESCRIPTION { get; set; }
        public DateTime DateOfChange { get; set; }
        public string NameAfterChange  { get; set; }
        public string NameBeforChange { get; set; }

        public void Audit(int id, bool createNew)
        {
            var dtNow = DateTime.UtcNow;

            if (createNew)
            {
                DateOfChange = DateOfChange;
                NAME = NAME;
            }

            DateOfChange = dtNow;
            ID = id;
        }
    }
}