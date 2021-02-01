using eticaretsitesi.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eticaretsitesi
{
    public class AndDB : DbContext
    {
        public AndDB()
            //VERİTABANI BAĞLAMAK İÇİN 1.YOL
            : base(@"Data Source=.;Initial Catalog=AndEticaretDB;Integrated Security=True")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<Odeme> Odemes { get; set; }
        public DbSet<UserAddress> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }


    }
}
