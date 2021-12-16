using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApi.Models
{
    public class Book_api
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public int PageCount { get; set; }
    }
}
