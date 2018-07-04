using System;

namespace AcademyDataStructureLINQ.Models
{
    public class Todo
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public bool isComplete { get; set; }
        public int userId { get; set; }

        public override string ToString()
        {
            return $"id:{id}, created at:{createdAt}, name:{name}, is completed:{isComplete}";
        }
    }
}
