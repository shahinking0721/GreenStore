using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Entities;
using App.Infra.Data.SqlServer.Ef.DbCTX.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.SqlServer.Ef.DbCTX;

public partial class GreenStoreDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public GreenStoreDbContext()
    {
    }

    public GreenStoreDbContext(DbContextOptions<GreenStoreDbContext> options)
        : base(options)
    {

    }
       
    public virtual DbSet<Auction> Auctions { get; set; }
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Sold> Sold { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //{
        //    relationship.DeleteBehavior = DeleteBehavior.NoAction;
        //}
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.Entity<Product>()
        .HasOne<Auction>(s => s.Auctions)
        .WithOne(h => h.Product)
        .OnDelete(DeleteBehavior.Restrict);
        base.OnModelCreating(modelBuilder);
    }

    

}
