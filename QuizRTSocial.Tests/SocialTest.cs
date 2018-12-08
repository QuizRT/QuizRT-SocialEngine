using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using quizartsocial_backend.Models;
using quizartsocial_backend.Services;
using backEnd.Controllers;
using Moq;

namespace QuizRTSocial.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            List<Topic> DD = new List<Topic>{
                new Topic{
                    topicId=1,
                    topicName="Prateek",
                    posts=null,
                    followers=null
                    
                }
            };

            //IEnumerable<QuestionGeneration> dummy = DD.DummyMock();  // Arrange
            
            Mock<ITopic> MockRepository = new Mock<ITopic>(); // Removing Dependency
            MockRepository.Setup<Task<List<Topic>>>
                (d => d.FetchTopicsFromDbAsync())
                    .Returns(Task.FromResult<List<Topic>>(DD));
            //MockRepository.Setup(d => d.FetchTopicsFromDbAsync()).Returns(DD);
            SocialController socialcontroller = new SocialController(MockRepository.Object); // Act
            var actual = System.Threading.Tasks.Task<List<Topic>>.Run(()=> socialcontroller.GetTopics());

            var okObjectResult = actual as Task<IActionResult>;
           // List<Topic> result = okObjectResult.Result;
            Assert.NotNull(okObjectResult);

            // var actualList = okObjectResult.Value as IEnumerable<QuestionGeneration>;

            //Assert.NotNull(actualList); // Assert
            // Console.WriteLine("actualList.Count: "+actualList.Count);
            // Assert.NotEqual(okObjectResult, 1);
        }
    }
}
