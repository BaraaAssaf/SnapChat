using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Story_Snapchat
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Path{ get; set; }
        public DateTime StartDate { get; set; }
        public int IsBlock{ get; set; }

        [ForeignKey("UserId")]
        public virtual User user { get; set; }
        public ICollection<Viewers_Snapchat> Viewers_Snapchats { get; set; }

    }
}

