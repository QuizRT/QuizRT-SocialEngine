using System;

namespace quizartsocial_backend.Models
{
    public class Follower
    {
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}