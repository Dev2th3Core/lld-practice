using C_.Models;
using System.Xml.Linq;

namespace C_.Services
{
    /// <summary>
    /// Service for managing users and their vehicles.
    /// </summary>
    class UserService
    {
        private readonly List<User> _users = new();

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <returns>The newly created <see cref="User"/>.</returns>
        public User AddUser(string name)
        {
            var user = new User
            {
                Name = name,
            };

            _users.Add(user);
            Console.WriteLine($"User created: {user.Name} (ID: {user.UserId})");
            return user;
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>The <see cref="User"/> if found; otherwise, null.</returns>
        public User GetUserById(Guid userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user is null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }
            return user;
        }

        /// <summary>
        /// Gets a list of all registered users.
        /// </summary>
        /// <returns>A list of all <see cref="User"/>s.</returns>
        public List<User> GetAllUsers()
        {
            return _users;
        }

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>True if the user was deleted; otherwise, false.</returns>
        public bool DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _users.Remove(user);
                Console.WriteLine($"User deleted: {user.Name}");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Associates a vehicle with a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="vehicle">The <see cref="Vehicle"/> to add to the user.</param>
        /// <returns>The added <see cref="Vehicle"/> if the user is found; otherwise, null.</returns>
        public Vehicle AddVehicleToUser(Guid userId, Vehicle vehicle)
        {
            var user = GetUserById(userId); // Throws if not found
            user.Vehicles.Add(vehicle);
            Console.WriteLine($"Vehicle {vehicle.LicensePlate} added to {user.Name}");
            return vehicle;
        }

        /// <summary>
        /// Displays all registered users and their vehicles to the console.
        /// </summary>
        public void DisplayAllUsers()
        {
            Console.WriteLine("\n--- Registered Users ---");
            foreach (var user in _users)
            {
                Console.WriteLine($"ID: {user.UserId}, Name: {user.Name}");
                if (user.Vehicles.Any())
                {
                    Console.WriteLine("  Vehicles:");
                    foreach (var v in user.Vehicles)
                        Console.WriteLine($"   - {v.Type}: {v.LicensePlate}");
                }
            }
        }
    }
}
