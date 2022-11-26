using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Data
{
    public class MsgContactus
    {
        [Key]
        public int Id { get; set; }
        public string name{ get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message{ get; set; }

    }
}
