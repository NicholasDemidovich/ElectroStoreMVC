using System.Linq;


namespace ElectroStoreMVC.Models
{
    public class InitializeDB
    {
        public static void Initialize(StoreContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Login = "Admin",
                        Password = "Admin",
                        Email = "Admin",
                        PhoneNumber = "Admin",
                        Address = "Admin",
                        FullName = "Admin"
                    }
                       
                );
                context.SaveChanges();
            }
        }
    }
}
