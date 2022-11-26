using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class orderservice_snapchat
    {

        [Key]
        public int id { get; set; }

        public int orderid { get; set; }
        public int serviceid { get; set; }


        [ForeignKey("orderid")]
        public virtual order_snapchat Order { get; set; }


        [ForeignKey("serviceid")]
        public virtual service_snapchat Service { get; set; }
    }
}




