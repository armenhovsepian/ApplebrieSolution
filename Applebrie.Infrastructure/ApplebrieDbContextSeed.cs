using Applebrie.Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

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
        }
    }
}
