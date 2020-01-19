using ITHS_DB_Lab5.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ITHS_DB_Lab5.Service
{
    public class PostService
    {
        private IMongoCollection<Post> posts;

        public PostService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("iths-db-lab5"));
            IMongoDatabase database = client.GetDatabase("iths-db-lab5");
            posts = database.GetCollection<Post>("Posts");
        }

        public List<Post> Get() =>
            posts.Find(post => true).ToList();

        public Post Get(string id) =>
            posts.Find<Post>(post => post.Id == id).FirstOrDefault();

        public Post Create(Post post)
        {
            posts.InsertOne(post);
            return post;
        }

        public void Remove(string id) =>
            posts.DeleteOne(post => post.Id == id);
    }
}
