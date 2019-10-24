using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace MvcTrendlog.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTrendlogContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTrendlogContext>>()))
            {

                // Look for any movies.
                if (context.AuthorModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.AuthorModel.AddRange(
                    new AuthorModel
                    {
                        Name = "Muslim",
                        Title = "C# Developer",
                        Earnings = 500,
                        FilePath = "./css/assets/images/avatars/9.jpg"
                    },

                    new AuthorModel
                    {
                        Name = "Muslim",
                        Title = "C# Developer",
                        Earnings = 500,
                        FilePath = "./css/assets/images/avatars/5.jpg"
                    },

                    new AuthorModel
                    {
                        Name = "Muslim",
                        Title = "C# Developer",
                        Earnings = 500,
                        FilePath = "./css/assets/images/avatars/4.jpg"
                    },

                    new AuthorModel
                    {
                        Name = "Muslim",
                        Title = "C# Developer",
                        Earnings = 500,
                        FilePath = "./css/assets/images/avatars/3.jpg"
                    },

                    new AuthorModel
                    {
                        Name = "Muslim",
                        Title = "C# Developer",
                        Earnings = 500,
                        FilePath = "./css/assets/images/avatars/2.jpg"
                    }
                );
                
            
                context.SaveChanges();
            }
        }
      
    }
}