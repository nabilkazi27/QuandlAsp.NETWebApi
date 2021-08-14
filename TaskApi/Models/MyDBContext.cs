using TaskApi.Models;  
using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks; 
  
namespace TaskApi.Models  
{  
    public class MyDBContext : DbContext  
    {  
        public DbSet<Stock> Stocks { get; set; }  
  
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)  
        {   
        }  
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            // Use Fluent API to configure  
  
            // Map entities to tables  
            modelBuilder.Entity<Stock>().ToTable("Stock");  
  
            // Configure Primary Keys  
            modelBuilder.Entity<Stock>().HasKey(u => u.StockDate).HasName("PK_Stock");  
  
            // Configure indexes  
            // modelBuilder.Entity<UserGroup>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");  
  
            // Configure columns  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockDate).HasColumnType("datetime").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockOpen).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockHigh).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockLow).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockClose).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockWAP).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockNoOfShares).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockNoOfTrades).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockTotalTurnover).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockDeliverableQuantity).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockDeliverableQuantityToTradedQuantityPercent).HasColumnType("double").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockSpreadHL).HasColumnType("decimal").IsRequired();  
            modelBuilder.Entity<Stock>().Property(ug => ug.StockSpreadCO).HasColumnType("decimal").IsRequired();  
  
            // Configure relationships  
            // modelBuilder.Entity<User>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");  
        }  
    }  
}