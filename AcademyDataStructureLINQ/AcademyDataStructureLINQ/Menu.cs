using AcademyDataStructureLINQ.Models;
using System;
using System.Collections.Generic;

namespace AcademyDataStructureLINQ
{
    public class Menu
    {
        Queries queries = new Queries();

        public void MainMenu()
        {         
            while (true)
            {
                Console.WriteLine("Please, chose the option.");
                Console.WriteLine(" 1 - Get amount of comments under users' posts;\n 2 - Get list of comments for certain user;\n 3 - Get list of completed todos for certain user;\n 4 - Get list of users ordered by alphabetical;\n 5 - Get user structure;\n 6 - Get post structure.");
                string actionKey = Console.ReadLine();

                if (actionKey.Length == 0)
                {
                    continue;
                }

                var key = Convert.ToChar(actionKey);

                switch (key)
                {
                    case '1':
                        GetAmountOfCommentsByUserIdPrint();
                        break;
                    case '2':
                        GetAllCommentsByUserIdPrint();
                        break;
                    case '3':
                        GetTodosByUserIdPrint();
                        break;
                    case '4':
                        GetListOfUsersPrint();
                        break;
                    case '5':
                        GetUserInformationPrint();
                        break;
                    case '6':
                        GetPostInformationPrint();
                        break;
                    default:
                        Console.WriteLine("Sorry, you input invalid data.");
                        break;
                }
            }
        }

        void GetAmountOfCommentsByUserIdPrint()
        {
            dynamic amountOfComments = queries.GetAmountOfCommentsByUserId(EnterUserId());

            Console.WriteLine($"Count of comments for all users' posts");

            foreach (var item in amountOfComments)
            {
                Console.WriteLine($"Post {item.post} has {item.amountOfComm} comments");
            }

            Console.WriteLine();
        }

        void GetAllCommentsByUserIdPrint()
        {
            dynamic comments = queries.GetAllCommentsByUserId(EnterUserId(), EnterLength());

            Console.WriteLine($"All comments for user where body is less then 50");

            ShowComments(comments);

            Console.WriteLine();
        }

        void GetTodosByUserIdPrint()
        {
            dynamic todos = queries.GetTodosByUserId(EnterUserId());

            Console.WriteLine($"All completed todos for user");

            ShowTodos(todos);

            Console.WriteLine();
        }

        void GetListOfUsersPrint()
        {
            dynamic result = queries.GetTodosByUserId(EnterUserId());

            Console.WriteLine($"List of users ordered by alphabetical");

            foreach (var item in result)
            {
                Console.WriteLine($"User {item.u}");
                ShowTodos(item.todos);
            }

            Console.WriteLine();
        }

        void GetUserInformationPrint()
        {
            dynamic result = queries.GetUserInformation(EnterUserId(), EnterLength());

            foreach (var item in result)
            {
                Console.WriteLine($" User: {item.user}\n Post:{item.lastPost}\n Amount of comments:{item.amountOfComm}\n Uncompleted tasks:{item.uncompletedTasks}\n Popular post by comments:{item.popularPostByComm}\n Popular post by likes:{item.popularPostByLikes}");
            }
            Console.WriteLine();
        }

        void GetPostInformationPrint()
        {
            dynamic post = queries.GetPostInformation(EnterUserId(), EnterLength());

            Console.WriteLine($"Information about post");

            foreach (var item in post)
            {
                Console.WriteLine($"Post {item.post}\nlonger comment:{item.longerComment}\nliker comment:{item.likerComment}\namount of comments:{item.amountOfComments}");
            }

            Console.WriteLine();
        }

        int EnterUserId()
        {
            Console.WriteLine("Enter the users' id");
            return int.Parse(Console.ReadLine());
        }

        int EnterLength()
        {
            Console.WriteLine("Enter the length");
            return int.Parse(Console.ReadLine());
        }

         void ShowTodos(IEnumerable<Todo> todos)
        {
            foreach (var todo in todos)
            {
                Console.WriteLine(todo);
            }
        }

         void ShowPost(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                Console.WriteLine(post);
            }
        }

         void ShowComments(IEnumerable<Comment> comments)
        {
            foreach (var comment in comments)
            {
                Console.WriteLine(comment);
            }
        }
    }
}
