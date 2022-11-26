using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class order_snapchat
    {
        [Key]
        public int id { get; set; }
        public int totalprice { get; set; }
        public int userid { get; set; }

        public DateTime orderdate { get; set; }
        public int serviceid { get; set; }

        //[ForeignKey("userid")]
        //public virtual  User_snapchat User { get; set; }

    }
}


