using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class message_snapchat
    {
        [Key]
        public int id { get; set; }
        public string text { get; set; }
        public string path{ get; set; }
        public DateTime messagedate { get; set; }
        public string status  { get; set; }

        public int issave { get; set; }

        public int senderid { get; set; }
        public int receiverid { get; set; }

    }
}
