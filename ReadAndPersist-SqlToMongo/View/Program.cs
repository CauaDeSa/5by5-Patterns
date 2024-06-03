using Model;
using Controller;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Radar> tempLst;
            int command = 0;

            do
            {
                Console.Clear();
                ShowMenu();

                command = ReadCommand();

                switch (command)
                {
                    case 1:
                        ShowRadars(new ViewController().GetSqlRadars());
                        break;

                    case 2:
                        ShowRadars(new ViewController().GetMongoRadars());
                        break;

                    case 3:
                        Console.WriteLine($"\n{(new ViewController().LoadMongo() ? "Mongo database populated!" : "Mongo database has been already populated!")}\n");
                        break;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();

            } while (command > 0 && command < 4);
        }

        public static void ShowRadars(List<Radar>? radars)
        {
            if (radars == null || radars.Count == 0)
            {
                Console.WriteLine("\nNo radars to show.\n");
                return;
            }

            Console.WriteLine("\n > RADARS <\n");

            foreach (var radar in radars)
                Console.WriteLine(radar);
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n > COMMANDS <\n");

            Console.Write("[1] Show SQL database\n" +
                          "[2] Show Mongo database\n" +
                          "[3] Populate Mongo from Sql\n" +

                          "[any other number] Exit\n\n" +
                          "Option: ");
        }

        private static string ReadString()
        {
            string? str;
            int cursorTop = Console.CursorTop;
            int cursorLeft = Console.CursorLeft;

            do
            {
                Console.SetCursorPosition(cursorLeft, cursorTop);
                str = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(str));

            return str;
        }

        private static int ReadCommand()
        {
            int command;
            int cursorTop = Console.CursorTop;
            int cursorLeft = Console.CursorLeft;

            try
            {
                command = int.Parse(ReadString());
            }
            catch (Exception)
            {
                ClearLine(cursorTop, cursorLeft);
                return ReadCommand();
            }

            return command;
        }

        private static void ClearLine(int top, int left)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine("                                                 ");
            Console.SetCursorPosition(left, top);
        }
    }
}