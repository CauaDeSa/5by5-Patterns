using Model;
using Controller;

namespace View
{
    class Program
    {
        private const string JsonFilePath = "C:\\Data\\radars.json";

        static void Main(string[] args)
        {
            int command;

            do
            {
                Console.Clear();
                ShowMenu();

                command = ReadCommand();

                switch (command)
                {
                    case 1:
                        ShowRadars(new ViewController().GetRadars());
                        break;

                    case 2:
                        Console.WriteLine($"\n{(new ViewController().LoadJsonData(JsonFilePath) ? "Local database populated!" : "Local database has been already populated!")}\n");
                        break;

                    case 3:
                        Console.WriteLine($"\n{(new ViewController().LoadSqlData() ? "Sql database populated!" : "Sql database has been already populated!")}\n");
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

            Console.Write("[1] Show all\n" +
                          "[2] Populate local\n" +
                          "[3] Populate sql\n" +
                          "[any other number] Exit\n\n" +
                          "Option: ");
        }

        public static string ReadString()
        {
            string? str;

            do
            {
                str = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(str));

            return str;
        }

        public static int ReadCommand()
        {
            int command;

            try
            {
                command = int.Parse(ReadString());
            }
            catch (Exception)
            {
                return ReadCommand();
            }

            return command;
        }
    }
}