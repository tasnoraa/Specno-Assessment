using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpecnoRepository.Models
{
    public class Like
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LikeId { get; set; }
        public bool UpVote { get; set; }
        public bool DownVote { get; set; }
        public int PostId { get; set; }
        //public Post Post { get; set; }
    }
}
