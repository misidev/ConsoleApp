using ConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();
        private int idCounter = 1;

        // Create a new user
        public void CreateUser(string name, string email, string password)
        {
            users.Add(new User { Id = idCounter++, Name = name, Email = email, Password = password });
        }

        // Get a list of all users
        public List<User> GetUsers()
        {
            return users;
        }

        // Get a user by their ID
        public User GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id) ?? throw new KeyNotFoundException($"User with ID {id} was not found.");
            return user;
        }

        // Update a user's details
        public bool UpdateUser(int id, string newName, string newEmail, string newPassword)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user.Name = newName;
                user.Email = newEmail;
                user.Password = newPassword;
                return true;
            }
            return false;
        }

        // Delete a user by their ID
        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }
    }
}
