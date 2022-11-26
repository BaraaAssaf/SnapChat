using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Report
    {

        [Key]
        public int id { get; set; }
        public String message { get; set; }
        public int reportfrom { get; set; }

        public int reportto { get; set; }
        public int status { get; set; }


        public DateTime  reportdate { get; set; }



    }
}
