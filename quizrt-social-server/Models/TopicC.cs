using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace quizartsocial_backend.Models
{
    public class Topic
    {
        [Key]
        public int topicId { get; set; }
        public string topicName { get; set; }
        public List<Post> posts { get; set; }
        public List<Follower> followers {get; set;}

    }
}

// public string topicImage { get; set; }