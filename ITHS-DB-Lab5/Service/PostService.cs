using ITHS_DB_Lab5.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            var categories = post.Categories[0].Split(' ');
            post.Categories = categories;
            posts.InsertOne(post);
            return post;
        }
        public void Update(string id, Post postIn)
        {
            var filter = Builders<Post>.Filter
             .Eq(p => p.Id, postIn.Id);
            var update = Builders<Post>.Update
                .Set("Title", postIn.Title)
                .Set("Text", postIn.Text);
            posts.UpdateOne(filter, update);
        }

        public IQueryable<DistinctCategories> GetAllCategories()
        {
            //var distinctItems = posts.Distinct(new StringFieldDefinition<Post, string>("Categories"), FilterDefinition<Post>.Empty).ToList();
            var duplicates = posts.AsQueryable()
                .SelectMany(p => p.Categories)
                .Select(key => new { Name = key })
                .GroupBy(info => info.Name)
                .Select(group => new DistinctCategories { Name = group.Key, Count = group.Count() });
            return duplicates;
        }

        public void Remove(string id) =>
            posts.DeleteOne(post => post.Id == id);
    }

    public class DistinctCategories
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
