using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class Visa_Snapchat
    {
        [Key]
        public int Id { get; set; }
        public int SecurityCode { get; set; }
        public DateTime ExpireDate { get; set; }
        public float Balance { get; set; }
        public long SerialNumber { get; set; }
    }
}
