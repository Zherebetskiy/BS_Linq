namespace AcademyDataStructureLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }
        //maybe I need use this variant
        /*
            var users = context.Users.GroupJoin(context.Todos, u => int.Parse(u.id), t => t.userId, (u, t) => new { u, t })
                                     .GroupJoin(context.Posts, up => up.u.id, p => p.id, (up, p) => new
                                     {
                                         id = up.u.id,
                                         name = up.u.name,
                                         createdAt = up.u.createdAt,
                                         todos = up.t.ToList(),
                                         post = p.GroupJoin(
                                              context.Comments,
                                              pt => int.Parse(pt.id),
                                              c => c.postId,
                                              (pt, c) => new
                                              {
                                                  id = pt.id,
                                                  likes = pt.likes,
                                                  title = pt.title,
                                                  body = pt.body,
                                                  createdAt = pt.createdAt,
                                                  comments = c.ToList()
                                              }).ToList()
                                     })
                                      .ToList();*/

    }
}
