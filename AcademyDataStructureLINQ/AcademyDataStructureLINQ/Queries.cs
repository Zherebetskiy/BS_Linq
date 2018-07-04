using AcademyDataStructureLINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyDataStructureLINQ
{
    static class Queries
    {
        static DataContext context = new DataContext();

        public static void GetAmountOfCommentsByUserId(int id)
        {
            var amountOfComments = context.Posts
              .Where(p => p.userId == id)
              .GroupJoin(context.Comments,
                  p => int.Parse(p.id),
                  c => c.postId,
                  (p, c) => new
                  {
                      post = p,
                      amountOfComm = c.Count()
                  });

            Console.WriteLine($"Count of comments for all users' posts with id {id}");

            foreach (var item in amountOfComments)
            {
                Console.WriteLine($"Post {item.post} has {item.amountOfComm} comments");
            }

            Console.WriteLine();
        }

        public static void GetAllCommentsByUserId(int id)
        {
            var comments = context.Comments
                .Where(c => c.userId == id && c.body.Length < 50)
                .Select(c => c);

            Console.WriteLine($"All comments for user with id {id} where body is less then 50");

            ShowComments(comments);

            Console.WriteLine();
        }

        public static void GetTodosByUserId(int id)
        {
            var todos = context.Todos
                .Where(t => t.userId == id && t.isComplete == true)
                .Select(t => t);

            Console.WriteLine($"All completed todos for user with id {id}");

            ShowTodos(todos);

            Console.WriteLine();
        }

        public static void GetListOfUsers()
        {
            var result = context.Users
            .GroupJoin(context.Todos,
                 u => int.Parse(u.id),
                 t => t.userId,
                 (u, t) => new { u, todos = t.OrderByDescending(item => item.name.Length).ToList() })
            .OrderBy(x => x.u.name);

            Console.WriteLine($"List of users ordered by alphabetical");

            foreach (var item in result)
            {
                Console.WriteLine($"User {item.u}");
                ShowTodos(item.todos);
            }

            Console.WriteLine();
        }


        public static void GetUserInformation(int id)
        {
            var users = context.Users
               .Where(u => int.Parse(u.id) == id)
               .GroupJoin(
                context.Todos,
                u => int.Parse(u.id),
                t => t.userId,
                (u, t) => new { u, t })
               .GroupJoin(
                context.Posts,
                ut => int.Parse(ut.u.id),
                p => p.userId,
                (ut, p) => new
                {
                    user = ut.u,
                    lastUserPost = p.OrderByDescending(pt => pt.createdAt).FirstOrDefault(),
                    amountOfComments = p.GroupJoin(
                        context.Comments,
                        pt => int.Parse(pt.id),
                        c => c.postId,
                        (pt, c) => new { pt, c }
                        )
                    .GroupBy(pst => pst.pt)
                    .Select(pst => new { post = pst.Key, com = pst.Count() })
                    .OrderByDescending(pt => pt.post.createdAt)
                    .FirstOrDefault(),

                    amountOfUncompleted = ut.t.Where(tk => tk.isComplete == false).Count(),
                    popularPostByLikes = p.OrderByDescending(pt => pt.likes).FirstOrDefault(),
                    popularPostByComm = p.Join(
                        context.Comments,
                        pt => int.Parse(pt.id),
                        c => c.postId,
                        (pt, c) => new { pt, c }
                        )
                     .Where(pst => pst.c.body.Length > 80)
                     .GroupBy(pst => pst.pt)
                     .Select(pst => new { post = pst.Key, com = pst.Count() })
                     .OrderByDescending(pt => pt.com)
                     .FirstOrDefault()
                }
               );
        }


        public static void GetPostInformation(int id)
        {
            var post = context.Posts
                .Where(p => int.Parse(p.id) == id)
                .GroupJoin(
                 context.Comments,
                 p => int.Parse(p.id),
                 c => c.postId,
                 (p, c) => new
                 {
                     post = p,
                     longerComment = c.OrderByDescending(cm => cm.body.Length).FirstOrDefault(),
                     likerComment = c.OrderByDescending(cm => cm.likes).FirstOrDefault(),
                     amountOfComments = c.Where(cm => cm.likes == 0 || cm.body.Length < 80).Count()
                 }
                );

            Console.WriteLine($"Information about post");

            foreach (var item in post)
            {
                Console.WriteLine($"Post {item.post}\nlonger comment:{item.longerComment}\nliker comment:{item.likerComment}\namount of comments:{item.amountOfComments}");
            }

            Console.WriteLine();
        }


        public static void ShowTodos(IEnumerable<Todo> todos)
        {
            foreach (var todo in todos)
            {
                Console.WriteLine(todo);
            }
        }

        public static void ShowPost(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                Console.WriteLine(post);
            }
        }

        public static void ShowComments(IEnumerable<Comment> comments)
        {
            foreach (var comment in comments)
            {
                Console.WriteLine(comment);
            }
        }
    }
}
