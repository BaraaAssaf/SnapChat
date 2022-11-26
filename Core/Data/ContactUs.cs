using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public String text1 { get; set; }
        public String text2 { get; set; }
        public String text3 { get; set; }
    }
}
