using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class User
    {
        [Key]
        public string userId { get; set; }
        public string userName { get; set; }
        public int score { get; set; }
        public List<Post> posts { get; set; }
        public List<Comment> comments { get; set; }
        public List<Follower> FollowedTopics  {get; set; }
        public int topicId {get; set; }

    }
}

 // public string userImage { get; set; }