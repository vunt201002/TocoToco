using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TocoToco.DL.Entities;

namespace TocoToco.DL.Context
{
    /// <summary>
    /// Lớp truy xuất đến cơ sở dữ liệu
    /// </summary>
    public class DataContext : DbContext
    {
        #region Constructors
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// hàm fluent api
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// created by: ntvu (20/08/2023)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToppingOrder>()
                .HasKey(to => new { to.ToppingId, to.OrderDetailId });
        } 
        #endregion

        #region DbSet
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<TypeOrder> TypeOrder { get; set; }
        public DbSet<SizeOrder> SizeOrder { get; set; }
        public DbSet<Sugar> Sugar { get; set; }
        public DbSet<Ice> Ice { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<ToppingOrder> ToppingOrder { get; set; }
        #endregion
    }
}
