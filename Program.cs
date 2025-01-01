using ConsoleApp.Services;
using ConsoleApp.Helpers;
using System;

class Program
{
    static void Main(string[] args)
    {
        var userService = new UserService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("3. Find User by ID");
            Console.WriteLine("4. Update User");
            Console.WriteLine("5. Delete User");
            Console.WriteLine("6. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": //Create User
                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty");
                        break;
                    }

                    Console.Write("Enter Email: ");
                    var email = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(email) || !ValidationHelper.IsValidEmail(email))
                    {
                        Console.WriteLine("Invalid email address");
                        break;
                    }

                    Console.Write("Enter Password: ");
                    var password = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(password) || !ValidationHelper.IsValidPassword(password))
                    {
                        Console.WriteLine("Password must be at least 8 characters long and include a number, a letter, and a special character.");
                        break;
                    }

                    userService.CreateUser(name, email, password);
                    Console.WriteLine("User created successfully.");
                    break;

                case "2": //View All Users
                    var users = userService.GetUsers();
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
                    }
                    break;

                case "3": //Find User by ID
                    Console.Write("Enter User ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        try
                        {
                            var user = userService.GetUserById(id);
                            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "4": //Update User
                    Console.Write("Enter User ID to Update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.Write("Enter New Name: ");
                        var newName = Console.ReadLine();

                        Console.Write("Enter New Email: ");
                        var newEmail = Console.ReadLine();

                        Console.Write("Enter New Password: ");
                        var newPassword = Console.ReadLine();

                        if (userService.UpdateUser(updateId, newName, newEmail, newPassword))
                        {
                            Console.WriteLine("User updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "5": //Delete User
                    Console.Write("Enter User ID to Delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        if (userService.DeleteUser(deleteId))
                        {
                            Console.WriteLine("User deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "6": //Exit
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}


