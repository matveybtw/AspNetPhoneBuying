using AspPhoneBuying.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace AspPhoneBuying.Context
{
    public class PhoneDbContext:DbContext
    {
        public PhoneDbContext(string connectionString) : base(connectionString)
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}