using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Dictionary to store student balances
        Dictionary<string, decimal> studentBalances = new Dictionary<string, decimal>
        {
            { "Belle Cacho", 7000 },
            { "Shaine Francisco", 8000 },
            { "Jhamir Go", 9000 },
            { "Mary Ann La Torre", 10000 }
        };

        // Dictionary to store student numbers
        Dictionary<string, string> studentNumbers = new Dictionary<string, string>
        {
            { "Belle Cacho", "s231106800" },
            { "Shaine Francisco", "s231106801" },
            { "Jhamir Go", "s231106802" },
            { "Mary Ann La Torre", "s231106803" }
        };

        string name;
        string studentNumber;

        do
        {
            Console.Clear(); // Clear the screen

            // Input student name
            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();

            // Input student number
            Console.WriteLine("Enter your student number:");
            studentNumber = Console.ReadLine();
            Console.Clear();

            // Check if student name and number match
            if (studentNumbers.ContainsKey(name) && studentNumbers[name] == studentNumber)
            {
                // Display student's name and balance
                Console.WriteLine($"Student name: {name}");
                Console.WriteLine($"Miscellaneous and Other Fees Balance: {studentBalances[name]}");

                // Options after checking balance
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Exit");
                Console.WriteLine("2. Pay now");

                // Input option
                Console.WriteLine("\nEnter your choice:");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2:");
                }
                Console.Clear(); // Clear the screen after user's choice

                // Process option
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Exiting...");
                        return;
                    case 2:
                        Console.WriteLine("Pay amount:");
                        decimal payAmount;
                        while (!decimal.TryParse(Console.ReadLine(), out payAmount) || payAmount < 0)
                        {
                            Console.WriteLine("Invalid amount. Please enter a valid positive number:");
                        }
                        if (payAmount > studentBalances[name])
                        {
                            Console.WriteLine("Amount exceeds balance. Payment unsuccessful.");
                        }
                        else
                        {
                            studentBalances[name] -= payAmount;
                            Console.WriteLine($"Current Balance: {studentBalances[name]}");
                            Console.WriteLine("\nOptions:");
                            Console.WriteLine("(1) Exit");
                            Console.WriteLine("(2) Log out");
                            Console.WriteLine("\nEnter your choice:");
                            int option;
                            while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
                            {
                                Console.WriteLine("Invalid choice. Please enter 1 or 2:");
                            }
                            if (option == 1)
                            {
                                Console.WriteLine("Exiting...");
                                return;
                            }
                            else
                            {
                                break;
                            }
                        }
                        return;
                }
            }
            else
            {
                Console.WriteLine("Not found.");

                // Prompt for retry or exit
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Retry");
                Console.WriteLine("2. Not now");

                // Input option
                Console.WriteLine("Enter your choice:");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || (option != 1 && option != 2))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2:");
                }
                if (option == 2)
                {
                    Console.WriteLine("Exiting...");
                    return;
                }
            }
        } while (true);
    }
}