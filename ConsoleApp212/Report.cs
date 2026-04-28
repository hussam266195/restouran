using res_user;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp212
{
    interface IEmployeeActions2
    {
        void report();
    }
    class Report : User

    {
        public Report(string username, string password)
        : base(username, password)
        {
        }
        public void report()
        {
            StreamReader sr = new StreamReader("add bill.txt");
            string test_product;
            while ((test_product = sr.ReadLine()) != null)
            {
                Console.ResetColor();
                Console.WriteLine(test_product);
            }
        }

        public override string GetRole()
        {
            return "Report";
        }

        public override void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Report Menu ---");
                Console.WriteLine("1. Read");
                Console.WriteLine("2. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    report();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Logging out...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }

        }
    }
}
