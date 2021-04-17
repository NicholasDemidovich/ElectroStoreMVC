using System.Linq;


namespace ElectroStoreMVC.Models
{
    public class InitializeDB
    {
        public static void Initialize(StoreContext context)
        {
           /* if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        UserName = "Admin",
                        PasswordHash = "AQAAAAEAACcQAAAAEPQbhw5qgI2DpYJgyQmzsOuYc6IOWAjYAr3pNZT8i0kyHbqM/7Oe6PY0xxsZncnAFQ==",
                        SecurityStamp = "f5632694-9f15-474f-a983-d761bb80683d",
                        ConcurrencyStamp = "4318c446-754c-4057-aeac-8a351ea94691",
                        Email = "Admin",
                        PhoneNumber = "Admin",
                        Address = "Admin",
                        FullName = "Admin",
                        LockoutEnabled = true
                    }
                       
                );
                context.SaveChanges();
            }*/
        }
    }
}
