using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int Isactive { get; set; }
        public int Isblock { get; set; }
        public int Roleid { get; set; }
        public int Userid { get; set; }
        public int Iserid { get; set; }
        [ForeignKey("Userid")]
        public virtual User user { get; set; }
        [ForeignKey("Roleid")]
        public virtual Role role { get; set; }
     
    }
}
