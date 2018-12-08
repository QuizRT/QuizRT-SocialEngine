using System;
using Microsoft.Extensions.Options;
using Neo4jClient;

namespace quizartsocial_backend.Services
{
    public class GraphDb : IDisposable
    {
        //var graph
        public GraphClient graph;
        public GraphDb(IOptions<Neo4jSettings> options)
        {
            var settings = options.Value;
            try
            {
                graph = new GraphClient(
                        new Uri(settings.ConnectionString),
                        settings.Username,
                        settings.Password
                    );
                graph.Connect();
            }
            catch (Exception e)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("-------------------------------------------------------------------------");
            }

        }

        public void Dispose()
        {
            graph.Dispose();
        }
    }
}