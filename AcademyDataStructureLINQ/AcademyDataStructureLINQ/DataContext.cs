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

        public List<User> Users
        {
            get { return JsonConvert.DeserializeObject<List<User>>(userResponse); }
        }

        public List<Post> Posts
        {
            get { return JsonConvert.DeserializeObject<List<Post>>(postResponse); }
        }

        public List<Comment> Comments
        {
            get { return JsonConvert.DeserializeObject<List<Comment>>(commentResponse); }
        }

        public List<Todo> Todos
        {
            get { return JsonConvert.DeserializeObject<List<Todo>>(todoResponse); }
        }

        public DataContext()
        {
            GetUserResponse().Wait();
            GetPostResponse().Wait();
            GetCommentResponse().Wait();
            GetTodoResponse().Wait();
        }

        async Task GetUserResponse()
        {
            userResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/users"));
        }

        async Task GetPostResponse()
        {
            postResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/posts"));
        }

        async Task GetCommentResponse()
        {
            commentResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/comments"));
        }

        async Task GetTodoResponse()
        {
            todoResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/todos"));
        }
    }
}
