using System;

namespace AcademyDataStructureLINQ
{
    public class Menu
    {
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
                        Queries.GetAmountOfCommentsByUserId(EnteredData());
                        break;
                    case '2':
                        Queries.GetAllCommentsByUserId(EnteredData());
                        break;
                    case '3':
                        Queries.GetTodosByUserId(EnteredData());
                        break;
                    case '4':
                        Queries.GetListOfUsers();
                        break;
                    case '5':
                        Queries.GetUserInformation(EnteredData());
                        break;
                    case '6':
                        Queries.GetPostInformation(EnteredData());
                        break;
                    default:
                        Console.WriteLine("Sorry, you input invalid data.");
                        break;
                }
            }
        }

        int EnteredData()
        {
            Console.WriteLine("Enter the users' id");
            return int.Parse(Console.ReadLine());
        }
    }
}
