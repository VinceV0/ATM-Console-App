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
        public static decimal balance = 0;
        //PIN constant global variable
        public const string PIN = "1234";

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
        }
        static void Main(string[] args)
        {
            CheckPin();
        }
    }
}
