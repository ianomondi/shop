using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onlineshop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlineshop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductTypes> productTypes { set; get; }
        public DbSet<SpecialTag> SpecialTags { set; get; }
        public DbSet<Product> Products { set; get; }
    }
}
