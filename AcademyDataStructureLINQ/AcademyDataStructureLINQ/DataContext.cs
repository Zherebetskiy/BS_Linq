using AcademyDataStructureLINQ.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcademyDataStructureLINQ
{
    public class DataContext
    {
        HttpClient client = new HttpClient();
        string userResponse;
        string postResponse;
        string commentResponse;
        string todoResponse;

        public List<User> Users { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Todo> Todos { get; set; }

        public DataContext()
        {
            GetUserList().Wait();
            GetPostResponse().Wait();
            GetCommentResponse().Wait();
            GetTodoResponse().Wait();
        }

        async Task GetUserList()
        {
            userResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/users"));
            Users = JsonConvert.DeserializeObject<List<User>>(userResponse);
        }

        async Task GetPostResponse()
        {
            postResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/posts"));
            Posts = JsonConvert.DeserializeObject<List<Post>>(postResponse);
        }

        async Task GetCommentResponse()
        {
            commentResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/comments"));
            Comments = JsonConvert.DeserializeObject<List<Comment>>(commentResponse);
        }

        async Task GetTodoResponse()
        {
            todoResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/todos"));
            Todos = JsonConvert.DeserializeObject<List<Todo>>(todoResponse);
        }
    }
}
