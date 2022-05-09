using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Console_App
{
    internal class Program
    {
        // Our allowed user input
        public static string[] menuOptions = {"View Balance", "Withdraw Funds", "Deposit Funds", "Exit" };
        //User balance of funds
        public static decimal balance = 100.00M;
        //PIN constant global variable
        public const string PIN = "1234";
        //Global variable holds user input
        public static string userInput;
        //Global variable holds how much money is to be withdrawn or deposited by user
        public static decimal withDep = 0M;

        static void CheckPin()
        {
            string pin = "";
            Console.WriteLine("\t******* Welcome to the ATM program *******\n\n\tPlease enter your PIN number");
            //User input
            pin = Console.ReadLine();
            //Use while loop to check pin
            while(pin != PIN)
            {
                if(pin == PIN)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\tPin number incorrect, enter again.");
                    pin = Console.ReadLine();
                }
            }
            Console.WriteLine("\tPin correct. Access granted.");
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("*******************************\n");
            Console.WriteLine("\tSelect an option:");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine("[" + (i+1).ToString() + "] "+ menuOptions[i]);
            }
            Console.WriteLine("*******************************\n");
            ProcessReq();
        }

        static void ProcessReq()
        {
            userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine(menuOptions[0] + " selected");
                Console.WriteLine("Your balance is: " + balance.ToString("c"));
                MainMenu();
            }
            else if (userInput == "2")
            {
                Console.WriteLine(menuOptions[1] + " selected");
                Console.WriteLine("How much would you like to withdraw?");
                try
                {
                    withDep = Convert.ToDecimal(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please input a valid number");
                }
                if (withDep <= balance)
                {
                    Console.WriteLine("Withdrawing: " + withDep.ToString("c"));
                    balance -= withDep;
                    Console.WriteLine("Your new balance is: " + balance.ToString("c"));
                }
                else
                {
                    Console.WriteLine("\nInadequate funds, please try another amount\n");
                }
                withDep = 0;
                MainMenu();
            }
            else if (userInput == "3")
            {
                Console.WriteLine(menuOptions[2] + " selected");
                Console.WriteLine("How much would you like to deposit?");
                try
                {
                    withDep = Convert.ToDecimal(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please input a valid number");
                }
                Console.WriteLine("Depositing " + withDep.ToString("c"));
                balance += withDep;
                Console.WriteLine("Your new balance is: " + balance.ToString("c"));
                withDep = 0;
                MainMenu();
            }
            else if (userInput == "4")
            {
                Console.WriteLine(menuOptions[3] + " selected");
                System.Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Not a valid input try again");
                ProcessReq();
            }
        }

        static void Main(string[] args)
        {
            CheckPin();
        }
    }
}
