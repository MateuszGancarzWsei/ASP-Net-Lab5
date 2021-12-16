using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Data
{
    public class Book_api_context : DbContext
    {
        public Book_api_context(DbContextOptions<Book_api_context> options)
            : base(options)
        {
        }

        public DbSet<BooksApi.Models.Book_api> Books { get; set; }
    }
}
