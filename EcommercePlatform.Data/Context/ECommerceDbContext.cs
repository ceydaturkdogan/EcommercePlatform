using ECommercePlatform.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommercePlatform.Data.Entities.UserEntity;

namespace ECommercePlatform.Data.Context
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            modelBuilder.Entity<SettingEntity>().HasData(
                new SettingEntity
                {
                    Id = 1,
                    MaintenanceMode = false
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users =>Set<UserEntity>();
        public DbSet<OrderEntity> Orders =>Set<OrderEntity>();
        public DbSet<OrderProductEntity> OrderProducts =>Set<OrderProductEntity>();
        public DbSet<ProductEntity> Products =>Set<ProductEntity>();
        public DbSet<SettingEntity> Settings =>Set<SettingEntity>();
        

    }
}
