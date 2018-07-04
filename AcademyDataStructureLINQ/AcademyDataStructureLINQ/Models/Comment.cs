using System;

namespace AcademyDataStructureLINQ.Models
{
    public class Comment
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public int postId { get; set; }
        public int likes { get; set; }

        public override string ToString()
        {
            return $"id:{id}, created at:{createdAt}, body:{body}, user id:{userId}, post id:{postId}, likes:{likes}";
        }
    }
}
