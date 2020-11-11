using System;
using System.Linq;
using System.Reflection;

namespace Records
{
    public record User(string UserName, int Id);

    public record Customer(string UserName, int Id, string Location) : User(UserName, Id);

    public record Employee(string DisplayName, int Id, string Location) : User(DisplayName, Id);

    public record CustomClonedUser(string UserName, int Id)
    {
        public CustomClonedUser(CustomClonedUser original) => (UserName, Id) = (original.UserName, -1);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User("Anu Viswan", 1);
            var user2 = new User("Anu Viswan", 1);
            var user3 = new User("Manu Viswan", 1);

            // Structural Equality  
            Console.WriteLine($"user1==user2 : {user1 == user2}");
            Console.WriteLine($"user1==user3 : {user1 == user3}");

            var user = new User("Anu Viswan", 1);
            var (userName, id) = user;

            var customer = new Customer("Anu Viswan", 1, "India");
            var employee = new Employee("Anu Viswan", 1, "India");

            Console.WriteLine(user.ToString());
            Console.WriteLine(customer.ToString());
            Console.WriteLine(employee.ToString());

            var anotherUser = user with
            {
                UserName = "Manu Viswan"
            };

            Console.WriteLine(anotherUser.ToString());

            var customUser = new CustomClonedUser("Anu Viswan", 1);
            var anotherCustomClonedUser = user with
            {
                UserName = "Manu Viswan"
            };

            Console.WriteLine(customUser.ToString());
            Console.WriteLine(anotherUser.ToString());
        }
       
    }
    
}
