using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quizartsocial_backend.Models
{
    public interface ITopic
    {
        Task<List<Post>> GetAllPostsForAUser(string userId);
        Task<List<User>> GetAllUsersAsync();
        Task FollowTopic(Follower follower);
        Task<List<Post>> GetAllPosts(); 
        Task CreatePost(Post post);
        Task CreateComment(Comment comment);
        Task AddTopicToDBAsync(Topic obj);
        Task DelTopicFromDBAsync(string topicName);
        Task DelTopicByIdAsync(int id);
        Task AddUserToDBAsync(User obj);
        Task AddCommentToDBAsync(Comment obj);
        Task<List<Post>> GetPostsForTopicAsync(string topicName);
        Task<List<Post>> GetPersonalisedPostsAsync(string userId);
        Task<Post> GetPostByIdAsyncFromDB(int postId);
        Task<List<Topic>> FetchTopicsFromDbAsync();
    }
}