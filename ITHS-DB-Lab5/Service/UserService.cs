using ITHS_DB_Lab5.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHS_DB_Lab5.Service
{
    public class UserService
    {
        private IMongoCollection<User> users;

        public UserService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("iths-db-lab5"));
            IMongoDatabase database = client.GetDatabase("iths-db-lab5");
            users = database.GetCollection<User>("Users");
        }

        public List<User> Get() =>
            users.Find(user => true).ToList();

        public User Get(string id) =>
            users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            users.InsertOne(user);
            return user;
        }

        

        public void Remove(string id) =>
            users.DeleteOne(user => user.Id == id);
    }
}
