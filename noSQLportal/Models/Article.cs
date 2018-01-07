using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace noSQLportal.Models
{
    public class Article
    {
        [BsonId]
        public MongoDB.Bson.ObjectId Id { get; set; }

        [BsonElement("title")]
        [Required]
        public string Title { get; set; }

        [BsonElement("content")]
        [Required]
        public string Content { get; set; }

        [BsonElement("author")]
        [Required]
        public string Author { get; set; }

        [BsonElement("comments")]
        public IList<string> Comments { get; set; } = new List<string>();

        [BsonElement("picture")]
        public byte[] Picture { get; set; }
    }
}
