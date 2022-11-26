using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public String rolename { get; set; }


      
    }
}
