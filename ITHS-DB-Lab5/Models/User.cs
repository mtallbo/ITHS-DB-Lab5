using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ITHS_DB_Lab5.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("FirstName")]
        [Required]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        [Required]
        public string LastName { get; set; }
    }
}
