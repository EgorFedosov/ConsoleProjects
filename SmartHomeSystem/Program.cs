namespace SmartHomeSystem
{
    internal class Program
    {
        private static int GetChoice()
        {
            while (true)
            {
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice >= 0 && choice <= 6)
                        return choice;
                    
                    Console.WriteLine("Invalid choice. Please enter a number between 0 and 6.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void HandleScenario(int choice, Controller controller)
        {
            switch (choice)
            {
                case 1:
                    controller.SetScenario(Controller.Scenario.Home);
                    Console.WriteLine("Scenario activated: I am home");
                    break;

                case 2:
                    controller.SetScenario(Controller.Scenario.Leave);
                    Console.WriteLine("Scenario activated: I am leaving");
                    break;

                case 3:
                    controller.SetScenario(Controller.Scenario.GoodNight);
                    Console.WriteLine("Scenario activated: Good night");
                    break;

                case 4:
                    controller.SetScenario(Controller.Scenario.GoodMorning);
                    Console.WriteLine("Scenario activated: Good morning");
                    break;

                case 5:
                    controller.SetScenario(Controller.Scenario.Party);
                    Console.WriteLine("Scenario activated: Party mode");
                    break;

                case 6:
                    Console.WriteLine("Displaying device information...");
                    controller.DeviceInfo();
                    break;

                case 0:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine(
                "1 - Scenario: I am home\n" +
                "2 - Scenario: I am leaving\n" +
                "3 - Scenario: Good night\n" +
                "4 - Scenario: Good morning\n" +
                "5 - Scenario: Party\n" +
                "6 - Device information\n" +
                "0 - Exit");
        }
        private static void Main()
        {
            var controller = new Controller();
            Console.WriteLine("Welcome to the smart home! The house has 20 smart lamps, 6 air conditioners, and 10 cameras.");

            while (true)
            { 
                ShowMenu(); 
                int choice = GetChoice(); 
                HandleScenario(choice, controller); 
            }
        }
    }

}