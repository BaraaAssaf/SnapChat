using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class getmessage_dto
    {
        public int id { get; set; }
        public string text { get; set; }
        public string path { get; set; }
        public int issave { get; set; }
        public int senderid { get; set; }
        public int receiverid { get; set; }
        public DateTime messagedate { get; set; }

    }
}
