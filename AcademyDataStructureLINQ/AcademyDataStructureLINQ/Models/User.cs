using System;

namespace AcademyDataStructureLINQ.Models
{
    public class User
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
       
        public override string ToString()
        {
            return $"id:{id}, created at:{createdAt}, name:{name}";
        }
    }
}
