using System;
using res_user;

namespace ConsoleApp212
{

    interface IEmployeeActions 
    {
        void AddMeal();
        void ViewMeals();
        void OrderMeal();
        void ViewBills();
        void SaveBill();
        
        
    }
   
    class Program
    {
        static void Main(string[] args)
        {
           
            Manager manager = new Manager("admin", "admin123");
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Restaurant Management System ===");
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                User currentUser = null;

                if (username == manager.Username && password == manager.Password)
                {
                    currentUser = manager;
                }
                else
                {
                    currentUser = manager.FindEmployee(username, password);
                }


                if (currentUser == null)
                {
                    Console.WriteLine("Invalid credentials. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

               
                Console.WriteLine($"Welcome, {currentUser.GetRole()}!");
                currentUser.ShowMenu();
            }
            
        }
       
    }
}
