using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpecnoRepository.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string PostMessage { get; set; }

        public int userId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
