using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }
        public string comment { get; set; }
        public int postId { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
    }
}