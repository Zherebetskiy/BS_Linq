using System;
using System.Collections.Generic;

namespace AcademyDataStructureLINQ.Models
{
    public class Post
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public int likes { get; set; }
        public List<Comment> comments { get; set; }

        public Post()
        {

        }

        public Post(Post p, List<Comment> comments)
        {
            id = p.id;
            createdAt = p.createdAt;
            title = p.title;
            body = p.body;
            userId = p.userId;
            likes = p.likes;
            this.comments = comments;
        }

        public override string ToString()
        {
            return $"id:{id}, created at:{createdAt}, title:{title}, user id:{userId},  likes:{likes}";
        }
    }
}
