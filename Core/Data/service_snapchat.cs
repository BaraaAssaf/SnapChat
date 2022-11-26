using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class service_snapchat
    {
        [Key]
        public int id { get; set; }

        public string servicename { get; set; }

        public string imagepath { get; set; }
        public int price { get; set; }
          
    }
}

