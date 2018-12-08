using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using quizartsocial_backend.Models;
using quizartsocial_backend.Services;

namespace backEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        ITopic topicObj;
        public SocialController(ITopic _topicObj)
        {
            this.topicObj = _topicObj;
            //topicObj.GetTopicsFromRabbitMQ();
        }
       
        [HttpGet("topics")]
        public async Task<IActionResult> GetTopics()
        {
            List<Topic> allTopics = await topicObj.FetchTopicsFromDbAsync();
            //return new OkObjectResult(allTopics);
            return Ok(allTopics);
        }

        [HttpGet]
        [Route("posts/{topicName}")]
        public async Task<IActionResult> GetPosts(string topicName)
        {
            List<Post> posts = await topicObj.GetPostsForTopicAsync(topicName);
            if(posts.Any())
            {
                return Ok(posts);                      
            }
            else
            {
                return NotFound("Posts for this topic not found");
            } 
        }

        [HttpGet]
        [Route("posts/user/id/{userId}")]

        public async Task<IActionResult> GetAllPostsForAUser(string userId)
        {
            var posts = await topicObj.GetAllPostsForAUser(userId);
            return Ok(posts);
        }

        [HttpGet]
        [Route("posts/all")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await topicObj.GetAllPosts();
            return Ok(posts);
        }

        [HttpPost]
        [Route("follow")]
        public async Task<IActionResult> FollowTopic(Follower follower)
        {
            await topicObj.FollowTopic(follower);
            return Ok();
        }

        [HttpGet]
        [Route("post/{id:int}")]
        public async Task<IActionResult> GetPostByIdAsync([FromRoute] int id)
        {
            Post post = await topicObj.GetPostByIdAsyncFromDB(id);
            return Ok(post);
        }

        [HttpGet]
        [Route("users")]

        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await topicObj.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("User/users")]

        public async Task<IActionResult> GetUsersFromUserModelAsync()
        {
            List <User> users = await topicObj.GetUsersFromUserModelAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("posts/user/{userId}")]
        public async Task<IActionResult> PersonalisedPosts([FromRoute] string userId)
        {
            List<Post> personalisedPosts = await topicObj.GetPersonalisedPostsAsync(userId);
            return Ok(personalisedPosts);   
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
                await topicObj.CreatePost(post);
             // await topicObj.AddPostToDBAsync;
            return Ok();
        }

        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            // User user =new User();
            // user.userName = comment.userName;
            // user.userId = comment.userId;
            // await topicObj.AddUserToDBAsync(user);
            // await topicObj.AddCommentToDBAsync(comment);
            await topicObj.CreateComment(comment);
            return Ok();
        }          
        
        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateUser([FromBody] User value)
        {            
            await topicObj.AddUserToDBAsync(value);
            return Ok();
        }

        [HttpDelete]
        [Route("topic/{topicName}")]
        public async Task<IActionResult> DeleteTopicAsync([FromRoute] string topicName)
        {
            await  topicObj.DelTopicFromDBAsync(topicName);
            return Ok();
        }

        [HttpDelete]
        [Route("topic/{id:int}")]
        public async Task<IActionResult> DeleteTopicFromIdAsync(int id)
        {
            await topicObj.DelTopicByIdAsync(id);
            return Ok();
        }
    }
}
