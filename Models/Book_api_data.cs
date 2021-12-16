using BooksApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BooksApi.Models
{
    public class Book_api_data
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Book_api_context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Book_api_context>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                    new Book_api
                    {
                        Id = 1,
                        Name = "Pan Tadeusz",
                        Author = "Adam Mickiewicz",
                        PageCount = 380,
                        Price = 25.00
                    },
                    new Book_api
                    {
                        Id = 2,
                        Name = "Potop",
                        Author = "Henryk Sienkiewicz",
                        PageCount = 400,
                        Price = 30.00                       
                    },
                    new Book_api
                    {
                        Id = 3,
                        Name = "Księgi Jakubowe",
                        Author = "Olga Tokarczuk",
                        PageCount = 315,
                        Price = 70.00
                    },
                    new Book_api
                    {
                        Id = 4,
                        Name = "Balladyna",
                        Author = "Juliusz Słowacki",
                        PageCount = 230,
                        Price = 30.00
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
