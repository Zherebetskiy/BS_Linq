using System;

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

        public override string ToString()
        {
            return $"id:{id}, created at:{createdAt}, title:{title}, user id:{userId},  likes:{likes}";
        }
    }
}
