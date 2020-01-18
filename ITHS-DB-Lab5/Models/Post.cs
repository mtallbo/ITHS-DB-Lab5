using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ITHS_DB_Lab5.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        [Required]
        public string Title { get; set; }

        [BsonElement("Text")]
        [Required]
        public string Text { get; set; }

        [BsonElement("DateCreated")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [Required]
        public DateTime DateCreated { get; set; }

        [BsonElement("Author")]
        [Required]
        public User Author { get; set; }

        [BsonElement("Categories")]
        public string[] Categories { get; set; }
    }
}
