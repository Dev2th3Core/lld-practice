using C_.Models;
using System.Xml.Linq;

namespace C_.Services
{
    class UserService
    {
        private readonly List<User> users = new List<User>();

        public User AddUser(string name)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Name = name,
            };

            users.Add(user);
            Console.WriteLine($"User created: {user.Name} (ID: {user.UserId})");
            return user;
        }

        public User GetUserById(Guid userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if(user is null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public bool DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"User deleted: {user.Name}");
                return true;
            }
            return false;
        }

        public void AddVehicleToUser(Guid userId, Vehicle vehicle)
        {
            var user = GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            user.Vehicles.Add(vehicle);
            Console.WriteLine($"Vehicle {vehicle.LicensePlate} added to {user.Name}");
        }

        public void DisplayAllUsers()
        {
            Console.WriteLine("\n--- Registered Users ---");
            foreach (var user in users)
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
