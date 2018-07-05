namespace AcademyDataStructureLINQ
{
    class Program
    {
        public static DataContext context = new DataContext();

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}
