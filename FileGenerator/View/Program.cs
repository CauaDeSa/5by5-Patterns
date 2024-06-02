using Model;
using Controller;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewController viewController = new();
            int command, auxCommand;

            do
            {
                Console.Clear();
                ShowMenu();

                command = ReadCommand();

                switch (command)
                {
                    case 1:
                        FormatMenu(ViewController.Sql);

                        auxCommand = ReadCommand();

                        switch (auxCommand)
                        {
                            case 1:
                                Console.WriteLine(viewController.GetCsvFromSql());
                                break;

                            case 2:
                                Console.WriteLine(viewController.GetXmlFromSql());
                                break;

                            case 3:
                                Console.WriteLine(viewController.GetJsonFromSql());
                                break;
                        }
                        break;

                    case 2:
                        FormatMenu(ViewController.Mongo);

                        auxCommand = ReadCommand();

                        switch (auxCommand)
                        {
                            case 1:
                                Console.WriteLine(viewController.GetCsvFromMongo());
                                break;

                            case 2:
                                Console.WriteLine(viewController.GetXmlFromMongo());
                                break;

                            case 3:
                                Console.WriteLine(viewController.GetJsonFromMongo());
                                break;
                        }
                        break;
                }

                Console.Write("\nPress any key to continue...");
                Console.ReadKey();

            } while (command > 0 && command < 3);
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\n > COMMANDS <\n");

            Console.Write("[1] Get archives from Sql\n" +
                          "[2] Get archives from Mongo\n" +
                          "[any other number] Exit\n\n" +
                          "Option: ");
        }

        public static void FormatMenu(string format)
        {
            Console.WriteLine($"\n > {format.ToUpper()} COMMANDS <\n");

            Console.Write("[1] Get CSV archive\n" +
                          "[2] Get XML archive\n" +
                          "[3] Get Json archive\n" +
                          "[any other number] Back\n\n" +
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