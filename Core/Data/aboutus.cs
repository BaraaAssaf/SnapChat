using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class aboutus
    {
       
        [Key]   
         public int id { get; set; }
         public string name { get; set; }

         public string imagePath { get; set; }
         public string text { get; set; }


    }
}
