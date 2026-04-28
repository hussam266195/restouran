using System;
using res_user;

namespace ConsoleApp212
{
    class Manager : User
    {
        private Employee[] employees;
        private int employeeCount;
        public DateTime Date { get; private set; }
        public Manager(string username, string password) : base(username , password)
        {
            employees = new Employee[3];
            employeeCount = 0;
            Date = DateTime.Now;
        }

        public override string GetRole()
        {
            return "Manager";
        }
      

        public override void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Manager Menu ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddEmployee();
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

        private void AddEmployee()
        {
            if (employeeCount >= employees.Length)
            {
                Console.WriteLine("Cannot add more employees. The system is full.");
                return;
            }

            Console.Write("Enter new employee username: ");
            string username = Console.ReadLine();
            Console.Write("Enter new employee password: ");
            string password = Console.ReadLine();

            if (FindEmployee(username) != null)
            {
                Console.WriteLine("An employee with this username already exists.");
                return;
            }

            employees[employeeCount] = new Employee(username, password);
            employeeCount++;
            Console.WriteLine("Employee added successfully.");
            Console.WriteLine(DateTime.Now);

           
        }

        public Employee FindEmployee(string username)
        {
            for (int i = 0; i < employeeCount; i++)
            {
                if (employees[i].Username == username)
                {
                    return employees[i];
                }
            }
            return null;
        }

        public Employee FindEmployee(string username, string password)
        {
            var emp = FindEmployee(username);

            if (emp != null && emp.Password == password)
            {
                return emp;
            }
            return null;
        }
     
    }
}
