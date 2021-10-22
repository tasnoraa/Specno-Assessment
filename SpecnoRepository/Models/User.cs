using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpecnoRepository.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string Username { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
