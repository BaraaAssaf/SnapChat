using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Data
{
    public class Viewers_Snapchat
    {
        [Key]
        public int Id { get; set; }
        public int StoryId { get; set; }
        public int ViewersId { get; set; }

        [ForeignKey("ViewersId")]
        public virtual User user { get; set; }

        [ForeignKey("StoryId")]
        public virtual Story_Snapchat Story_Snapchat  { get; set; }
    }
}
