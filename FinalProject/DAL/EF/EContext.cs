using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.EF
{
    internal class EContext : DbContext 
    {
        public DbSet<Model.Buyer> Buyers { get; set; }
        public DbSet<Model.Products> Products { get; set; }
        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<Model.Brand> Brands { get; set; }
        public DbSet<Model.Category> Categories { get; set; }
        public DbSet<Model.Sellers> Sellers { get; set; }
        public DbSet<Model.Review> Reviews { get; set; }
        public DbSet<Model.Cart> Carts { get; set; }
        public DbSet<Model.Token> Tokens { get; set; }
        public DbSet<Model.VerificationCode> VerificationCodes { get; set; }

    }
}
