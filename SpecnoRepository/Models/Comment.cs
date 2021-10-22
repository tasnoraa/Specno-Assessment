using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpecnoRepository.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        public string CommentMessage { get; set; }

        public int PostId { get; set; }
    }
}
