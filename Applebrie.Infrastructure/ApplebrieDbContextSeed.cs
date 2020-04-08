using Applebrie.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Applebrie.Infrastructure
{
    public class ApplebrieDbContextSeed
    {
        public static void SeedData(ApplebrieDbContext context)
        {
            SeedUserType(context);
        }

        private static void SeedUserType(ApplebrieDbContext context)
        {
            if (!context.UserTypes.Any())
            {
                var seeds = new List<UserType>
                {
                    new UserType{ Name = "Administrator"},
                    new UserType{ Name ="User"},
                    new UserType{ Name = "Guest"}
                };

                foreach (var seed in seeds)
                {
                    context.UserTypes.Add(seed);
                }

                context.SaveChanges();
            }


            if (!context.Users.Any())
            {
                var admin = context.UserTypes.SingleOrDefault(u => u.Name == "Administrator");

                var user = new User {FirstName = "Armen", LastName = "Hovsepian", UserType = admin};
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
