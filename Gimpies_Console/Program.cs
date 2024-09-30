using System;
using System.Diagnostics;
using System.Threading;

namespace Gimpies_Console
{
    //if (Gimpies_Console.Sil != 0 erros) {for(int i = 0; i<error; error--;){error--;}}
    internal class Programtes
    {
        private static int Attempts = 3;  // int: Represents the number of login attempts allowed.
        private static readonly string[,] inventory = new string[100, 7]; // 7 columns // string[,]: A 2D array for inventory, storing up to 100 shoes with 7 properties (ID, brand, etc.).
        private static int inventoryCount = 0;  // int: Keeps track of how many shoes have been added to the inventory.
        private static int nextShoeID = 1; // int: ID for the next shoe to be added, starts from 1 and increments.

        private static void Main(string[] _)
        {
            PreloadInventory(); // Preload 6 pairs of shoes into the inventory when the program starts
            Console.WriteLine("    __                 _                                       \r\n   / /   ____  ____ _(_)___     __________________  ___  ____ \r\n  / /   / __ \\/ __ / / __ \\   / ___/ ___/ ___/ _ \\/ _ \\/ __ \\\r\n / /___/ /_/ / /_/ / / / / /  (__  ) /__/ /  /  __/  __/ / / /\r\n/_____/\\____/\\__, /_/_/ /_/  /____/\\___/_/   \\___/\\___/_/ /_/ \r\n            /____/  ");
            Loginscreen();
        } // Call the login screen

        // Preloads inventory: Adds 6 pre-defined shoes to the inventory and assigns unique IDs to them.
        private static void ShowMenu()
        {
            while (true) // Infinite loop until user exits the program.
            {
                Console.Clear(); // Clear the console screen.
                Console.WriteLine(
                    " /$$      /$$  /$$$$$$  /$$$$$$ /$$   /$$       /$$      /$$ /$$$$$$$$ /$$   /$$ /$$   /$$\r\n| $$$    /$$$ /$$__  $$|_  $$_/| $$$ | $$      | $$$    /$$$| $$_____/| $$$ | $$| $$  | $$\r\n| $$$$  /$$$$| $$  \\ $$  | $$  | $$$$| $$      | $$$$  /$$$$| $$      | $$$$| $$| $$  | $$\r\n| $$ $$/$$ $$| $$$$$$$$  | $$  | $$ $$ $$      | $$ $$/$$ $$| $$$$$   | $$ $$ $$| $$  | $$\r\n| $$  $$$| $$| $$__  $$  | $$  | $$  $$$$      | $$  $$$| $$| $$__/   | $$  $$$$| $$  | $$\r\n| $$\\  $ | $$| $$  | $$  | $$  | $$\\  $$$      | $$\\  $ | $$| $$      | $$\\  $$$| $$  | $$\r\n| $$ \\/  | $$| $$  | $$ /$$$$$$| $$ \\  $$      | $$ \\/  | $$| $$$$$$$$| $$ \\  $$|  $$$$$$/\r\n|__/     |__/|__/  |__/|______/|__/  \\__/      |__/     |__/|________/|__/  \\__/ \\______/ "
                );
                // Displaying menu options and accepting user's input.
                Console.WriteLine(" \n \n " +
                    "\n---------------------------------\n" +
                    "Please select an option:" +
                    "\n---------------------------------\n" +
                    "1. View Inventory" +
                    "\n---------------------------------\n" +
                    "2. Order Shoes" +
                    "\n---------------------------------\n3." +
                    " Log-Out" +
                    "\n---------------------------------\n" +
                    "0. Exit" +
                    "\n---------------------------------\n" +
                    "\n\n");
                // string: Input for the user's menu selection.
                Console.Write("Enter your choice:");
                string CHinput = Console.ReadLine();
                // int: Convert the user's input to a choice number.
                if (int.TryParse(CHinput, out int choice))
                {
                    // Execute different actions based on the user's menu choice.
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ViewInventory(); // View the current inventory.
                            break;

                        case 2:
                            Console.Clear();
                            OrderShoes(); // Allow the user to order shoes.
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine(
   "    __                _                                       \r\n   / /   ____  ____ _(_)___     __________________  ___  ____ \r\n  / /   / __ \\/ __ / / __ \\   / ___/ ___/ ___/ _ \\/ _ \\/ __ \\\r\n / /___/ /_/ / /_/ / / / / /  (__  ) /__/ /  /  __/  __/ / / /\r\n/_____/\\____/\\__, /_/_/ /_/  /____/\\___/_/   \\___/\\___/_/ /_/ \r\n            /____/  ");
                            Loginscreen(); // Go back to the login screen.
                            Attempts = 3; // Reset login attempts.
                            break;

                        case 0:
                            Console.WriteLine("Exiting...");
                            Environment.Exit(0); // Exit the program.
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please try again."); // Handle invalid input.
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again.");
                    Console.ReadKey();
                    ShowMenu();
                }
            }
        }

        private static void PreloadInventory()
        {
            // string[,]: Array holding preloaded shoe details.
            string[,] initialShoes =
            {
                { "Nike", "Jordan", "42, 41, 40, 39, 38", "Black", "10", "120.00" },
                { "Adidas", "Samba", "43, 42, 41, 40, 39", "White", "15", "85.00" },
                { "Puma", "Walkers", "44, 43, 42, 41, 40", "Red", "12", "100.00" },
                { "Reebok", "Scaler", "45, 44, 43, 42, 41", "Blue", "8", "95.00" },
                { "New Balance", "Treads", "40, 39, 38, 37, 36", "Grey", "20", "110.00" },
                { "Asics", "Sicans", "41, 40, 39, 38, 37", "Green", "18", "130.00" }
            };

            // Adds each shoe to the inventory and assigns unique IDs.
            for (int i = 0; i < initialShoes.GetLength(0); i++)
            {
                inventory[inventoryCount, 0] = nextShoeID.ToString(); // Assign a unique ID
                for (int j = 0; j < initialShoes.GetLength(1); j++)
                {
                    inventory[inventoryCount, j + 1] = initialShoes[i, j]; // Add the shoe details
                }
                nextShoeID++; // Increment the shoe ID
                inventoryCount++;
            }
        }

        // Displays all shoes in the inventory.
        private static void ViewInventory()
        {
            // If no shoes are in inventory, notify the user.
            if (inventoryCount == 0)
            {
                Console.WriteLine("The inventory is empty.");
                return;
            }
            // Displays the headers for the shoe details.
            Console.WriteLine("ID   Brand        Type        Size    Color      Amount      Price");
            Console.WriteLine("-------------------------------------------------------------------------");
            // Loops through the inventory and displays each shoe's details.
            for (int i = 0; i < inventoryCount; i++)
            {
                Console.WriteLine($"{inventory[i, 0],-4} {inventory[i, 1],-12} {inventory[i, 2],-10} {inventory[i, 3],-6} {inventory[i, 4],-7} {inventory[i, 5],-7} {inventory[i, 6]}");
            }
            Console.ReadKey();
        }

        // Allows the user to order shoes by selecting a shoe from the preloaded inventory.
        private static void OrderShoes()
        {
            // If no shoes are in inventory, notify the user.
            if (inventoryCount == 0)
            {
                Console.WriteLine("The inventory is empty.");
                return;
            }
            // Displays the headers for the shoe details.
            Console.WriteLine("ID   Brand        Type        Size    Color      Amount      Price");
            Console.WriteLine("-------------------------------------------------------------------------");
            // Loops through the inventory and displays each shoe's details.
            for (int i = 0; i < inventoryCount; i++)
            {
                Console.WriteLine($"{inventory[i, 0],-4} {inventory[i, 1],-12} {inventory[i, 2],-10} {inventory[i, 3],-6} {inventory[i, 4],-7} {inventory[i, 5],-7} {inventory[i, 6]}");
            }

            Console.WriteLine("Choose from the available shoes above by entering the shoe ID:");
            // string: Read the user's input for the shoe ID.
            Console.Write("Enter *E* to return to previous menu/ Enter the shoe ID to order: ");
            string input = Console.ReadLine();
            if (input == "E")
            {
                ShowMenu();
            }

            if (input == "")
            {
            }
            // Converts the user's input to an integer (shoe ID), validating the input.
            if (!int.TryParse(input, out int shoeID))
            {
                Console.WriteLine("Invalid input. Please enter a valid shoe ID or input *E* to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
                OrderShoes(); // Restart the order process
                return;
            }
            // bool: Indicates whether the shoe was found or not.
            bool shoeFound = false;
            // Loop through the inventory to find the shoe by its ID.
            for (int i = 0; i < inventoryCount; i++)
            {
                if (inventory[i, 0] == shoeID.ToString()) // Check if shoe ID matches
                {
                    shoeFound = true;
                    // Ask for the order amount
                    Console.Write("Enter the amount to order (maximum 150): ");
                    string amountInput = Console.ReadLine();
                    // Validate the amount input

                    if (!int.TryParse(amountInput, out int orderAmount) || orderAmount <= 0 || orderAmount > 150)
                    {
                        Console.WriteLine("Invalid amount. You can order between 1 and 150 shoes.");
                        Console.ReadKey(); // Wait for user to acknowledge the message
                        Console.Clear();
                        OrderShoes(); // Restart the order process
                        return;
                    }
                    // Update the current stock with the new order
                    int currentAmount = int.Parse(inventory[i, 5]); // Get current stock amount
                    inventory[i, 5] = (currentAmount + orderAmount).ToString(); // Update stock
                    Console.WriteLine($"Order placed! {orderAmount} units added to the inventory.");
                    OrdershoesReturner();
                }
            }
            // If no shoe with the provided ID was found, inform the user.
            if (!shoeFound)
            {
                Console.WriteLine("Shoe with that ID not found. Please try again Or type *E* to exit back to the main menu.");
                Console.ReadKey(); // Wait for user to acknowledge the message
                Console.Clear();
                OrderShoes(); // Restart the order process
            }
            Console.ReadKey();
        }

        // Displays the menu options and allows user to select actions.
        private static void OrdershoesReturner()
        {
            Console.WriteLine(
                "----------------\n" +
                "1. Order another shoe" +
                "\n----------------\n" +
                "2. Back to Main Menu" +
                "\n----------------"
                );
            Console.WriteLine("Input:");
            string OrdershoesInputStr = Console.ReadLine();
            if (int.TryParse(OrdershoesInputStr, out int OrdershoesInputInt))
            {
                switch (OrdershoesInputInt)
                {
                    case 1:
                        Console.Clear();
                        OrderShoes();
                        break;

                    case 2:
                        Console.Clear();
                        ShowMenu();
                        break;

                    default:
                        return;
                }
            }
        }

        // Handles the login process for the user.
        private static void Loginscreen()
        {
            // string: Constants for the correct login credentials.
            const string correctUsername = "Inkoop";
            const string correctPassword = "Gimpies_Inkoop";
            const string testUser = "test";
            const string testPass = "test";
            // string: Input for the username.
            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();
            // string: Input for the password.
            Console.Write("Enter your password: ");
            string password = "";
            // Loop to read and hide the password characters.
            while (true)
            {
                var key = Console.ReadKey(true); // Reads key but hides it from the console.
                if (key.Key == ConsoleKey.Enter)
                    break;
                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1); // Removes last character on backspace.
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar; // Append typed character to the password string.
                    Console.Write("⚫"); // Display an asterisk for each character.
                }
            }
            Console.WriteLine();
            if ( // Verifies if the entered credentials match either of the predefined users.
                username == correctUsername && password == correctPassword
                || username == testUser && password == testPass
            )
            {
                Attempts = 3; // Reset the number of attempts after successful login.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful! Welcome, " + username + "!");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                ShowMenu(); // After login, show the menu.
            }
            else
            {
                Attempts--; // Reduce the number of login attempts
                Console.WriteLine(
                   "Login failed. Incorrect username or password. " + Attempts + " Attempts left.");
                Console.ReadKey();

                if (Attempts == 0) // If no attempts are left, close the program.
                {
                    Console.WriteLine("Too many failed attempts, Application will close in 3 seconds.");
                    Thread.Sleep(3000);
                    Process.GetCurrentProcess().Kill(); // Forcefully closes the program.
                }
                if (Attempts > 0 && Attempts < 3)
                {
                    Console.Clear();
                    Console.WriteLine(
   "    __                _                                       \r\n   / /   ____  ____ _(_)___     __________________  ___  ____ \r\n  / /   / __ \\/ __ / / __ \\   / ___/ ___/ ___/ _ \\/ _ \\/ __ \\\r\n / /___/ /_/ / /_/ / / / / /  (__  ) /__/ /  /  __/  __/ / / /\r\n/_____/\\____/\\__, /_/_/ /_/  /____/\\___/_/   \\___/\\___/_/ /_/ \r\n            /____/  ");
                    Loginscreen(); // If attempts are left, re-display the login screen.
                    Console.WriteLine(
                    "Login failed. Incorrect username or password. " + Attempts + " Attempts left.");
                    Console.ReadKey();
                }
            }
        }
    }
}