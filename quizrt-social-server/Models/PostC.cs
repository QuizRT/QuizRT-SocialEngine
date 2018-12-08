using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class Post
    {
        [Key]
        public int postId{get; set;}
        public string post{get; set;}
        public List<Comment> comments{get; set;}
        public int topicId { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }

        public Topic topic { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
