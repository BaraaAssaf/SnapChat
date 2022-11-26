using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string imagepath { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime dateofbirth { get; set; }
        public string address { get; set; }
    }
}
