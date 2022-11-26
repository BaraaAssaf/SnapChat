using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class getalluser_dto
    {
        public int loginid { get; set; }
        public string username { get; set; }
        public int userid { get; set; }
        public string imagepath { get; set; }
        public int isblock { get; set; }
    }
}
