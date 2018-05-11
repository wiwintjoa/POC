﻿using Books.Domain.Model;
using System.Data.Entity;

namespace Books.DataAccess
{
    public class BooksAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public BooksAPIContext() : base("name=BooksAPIContext")
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Throttling> Throttlings { get; set; }
    }
}
