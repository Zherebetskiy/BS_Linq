using System;
using System.Collections.Generic;

namespace AcademyDataStructureLINQ.Models
{
    public class User
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public List<Todo> todos { get; set; }
        public List<Post> posts { get; set; }

        public User()
        {

        }
        
        public User(User user,List<Post> posts, List<Todo> todos)
        {
            id = user.id;
            createdAt = user.createdAt;
            name = user.name;
            this.posts = posts;
            this.todos = todos;
        }

        public override string ToString()
        {
            return $"id:{id}, created at:{createdAt}, name:{name}";
        }
    }
}
