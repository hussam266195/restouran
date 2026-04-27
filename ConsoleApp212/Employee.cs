using res_user;
using System;
using System.IO;

namespace ConsoleApp212
{
    class Employee : User, IEmployeeActions
    {
        public Employee(string username, string password) : base(username, password)
        {
        }

        public override string GetRole()
        {
            return "Employee";
        }

        public override void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Menu ---");
                Console.WriteLine("1. Add Meal");
                Console.WriteLine("2. View Meals");
                Console.WriteLine("3. Order Meal");
                Console.WriteLine("4. View Bills");
                Console.WriteLine("5. Logout");
                Console.WriteLine("6. save bill");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMeal();
                        break;
                    case "2":
                        ViewMeals();
                        break;
                    case "3":
                        OrderMeal();
                        break;
                    case "4":
                        ViewBills();
                        break;
                    case "5":
                        Console.WriteLine("Logging out...");
                        return;
                    case "6":
                        SaveBill();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        public void AddMeal()
        {
            Console.Write("Enter meal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter meal price: ");
            int price = int.Parse(Console.ReadLine());

            RestaurantData.Meals.Add(new Meal(name,price));

            Console.WriteLine("Meal added successfully.");
        }

        public void ViewMeals()
        {
            if (RestaurantData.Meals.Count == 0)
            {
                Console.WriteLine("No meals available.");
                return;
            }

            Console.WriteLine("\n--- Meal List ---");

            foreach (var meal in RestaurantData.Meals)
            {
                Console.WriteLine($"{meal.Name} - ${meal.Price}");
            }
        }

        public void OrderMeal()
        {
            Console.Write("Enter meal name to order: ");
            string mealName = Console.ReadLine();

            Meal foundMeal = null;

            foreach (var meal in RestaurantData.Meals)
            {
                if (meal.Name.ToLower() == mealName.ToLower())
                {
                    foundMeal = meal;
                    break;
                }
            }

            if (foundMeal == null)
            {
                Console.WriteLine("Meal not found.");
                return;
            }

            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            decimal total = foundMeal.Price * quantity;


            Bill bill = new Bill(foundMeal.Name, quantity, total, Username);

            RestaurantData.Bills.Add(bill);  ///// or  RestaurantData.Bills.Add(new Bill(foundMeal.Name, quantity, total, Username));


            Console.WriteLine("Order placed: " + quantity + "x " + foundMeal.Name + ", Total: $" + total);
        }

        public void ViewBills()
        {
            if (RestaurantData.Bills.Count == 0)
            {
                Console.WriteLine("No bills available.");
                return;
            }

            Console.WriteLine("\n--- All Bills ---");
            foreach (var bill in RestaurantData.Bills)
            {
                Console.WriteLine($"time : {bill.Date} name :  {bill.MealName} x{bill.Quantity} " +
                                  $"Total: ${bill.Total} (Ordered by: {bill.OrderedBy})");
            }
        }
        public void SaveBill()
        {
            StreamWriter ss = new StreamWriter("add bill.txt");
            foreach (var bill in RestaurantData.Bills)
            {
               ss.WriteLine($"time : {bill.Date} name :  {bill.MealName} x{bill.Quantity} " +
                                  $"Total: ${bill.Total} (Ordered by: {bill.OrderedBy})");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Save Data Is done!");
            Console.ResetColor();
            ss.Close();
        }
    }
    
}
