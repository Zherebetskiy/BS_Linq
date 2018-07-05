using AcademyDataStructureLINQ.Models;
using System.Collections.Generic;
using System.Linq;

namespace AcademyDataStructureLINQ
{
    public class Queries
    {
        DataContext context = new DataContext();
        IEnumerable<User> users;

        public Queries()
        {
            users = from user in context.Users
                    join post in (from p in context.Posts
                                  join comment in context.Comments on int.Parse(p.id) equals comment.postId into postComment
                                  select new Post(p, postComment.ToList())) on int.Parse(user.id) equals post.userId into postComments
                    join todo in context.Todos on int.Parse(user.id) equals todo.userId into todos
                    select new User(user, postComments.ToList(), todos.ToList());
        }

        public object GetAmountOfCommentsByUserId(int id)
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

            return amountOfComments;
        }

        public object GetAllCommentsByUserId(int id, int length)
        {
            var comments = users.Where(u => int.Parse(u.id) == id)
                .SelectMany(u => u.posts.SelectMany(p => p.comments.Where(c => c.body.Length < length)));

            return comments;          
        }

        public object GetTodosByUserId(int id)
        {
            var todos = users.Where(u => int.Parse(u.id) == id)
                .SelectMany(u => u.todos.Where(t => t.isComplete == true));

            return todos;
        }

        public object GetListOfUsers()
        {
            var result = context.Users
            .GroupJoin(context.Todos,
                 u => int.Parse(u.id),
                 t => t.userId,
                 (u, t) => new { u, todos = t.OrderByDescending(item => item.name.Length).ToList() })
            .OrderBy(x => x.u.name);

            return result;
        }


        public object GetUserInformation(int id, int length)
        {
            var result = users.Where(u => int.Parse(u.id) == id)
                .Select(u => new
                {
                    user = u,
                    lastPost = u.posts.OrderByDescending(p => p.createdAt).FirstOrDefault(),
                    amountOfComm = u.posts.OrderByDescending(p => p.createdAt).FirstOrDefault().comments.Count(),
                    uncompletedTasks = u.todos.Where(t => t.isComplete == false).Count(),
                    popularPostByComm = u.posts.OrderBy(p => p.comments.Where(c => c.body.Length > length).Count()).FirstOrDefault(),
                    popularPostByLikes = u.posts.OrderByDescending(p => p.likes).FirstOrDefault()
                });

            return result;
            //var userss = context.Users
            //   .Where(u => int.Parse(u.id) == id)
            //   .GroupJoin(
            //    context.Todos,
            //    u => int.Parse(u.id),
            //    t => t.userId,
            //    (u, t) => new { u, t })
            //   .GroupJoin(
            //    context.Posts,
            //    ut => int.Parse(ut.u.id),
            //    p => p.userId,
            //    (ut, p) => new
            //    {
            //        user = ut.u,
            //        lastUserPost = p.OrderByDescending(pt => pt.createdAt).FirstOrDefault(),
            //        amountOfComments = p.GroupJoin(
            //            context.Comments,
            //            pt => int.Parse(pt.id),
            //            c => c.postId,
            //            (pt, c) => new { pt, c }
            //            )
            //        .GroupBy(pst => pst.pt)
            //        .Select(pst => new { post = pst.Key, com = pst.Count() })
            //        .OrderByDescending(pt => pt.post.createdAt)
            //        .FirstOrDefault(),

            //        amountOfUncompleted = ut.t.Where(tk => tk.isComplete == false).Count(),
            //        popularPostByLikes = p.OrderByDescending(pt => pt.likes).FirstOrDefault(),
            //        popularPostByComm = p.Join(
            //            context.Comments,
            //            pt => int.Parse(pt.id),
            //            c => c.postId,
            //            (pt, c) => new { pt, c }
            //            )
            //         .Where(pst => pst.c.body.Length > 80)
            //         .GroupBy(pst => pst.pt)
            //         .Select(pst => new { post = pst.Key, com = pst.Count() })
            //         .OrderByDescending(pt => pt.com)
            //         .FirstOrDefault()
            //    }
            //   );
        }


        public object GetPostInformation(int id,int length)
        {
            var post = users.SelectMany(u => u.posts)
                .Where(p => int.Parse(p.id) == id)
                .Select(p => new
                {
                    post = p,
                    longerComment = p.comments.OrderByDescending(c => c.body).FirstOrDefault(),
                    likerComment = p.comments.OrderByDescending(c => c.likes).FirstOrDefault(),
                    amountOfComments = p.comments.Where(cm => cm.likes == 0 || cm.body.Length < length).Count()
                });

            return post;
        }
    }
}
