﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SneakerStore.Models;

public class SneakerDbContext : DbContext
{
    public SneakerDbContext(DbContextOptions<SneakerDbContext> options)
        : base(options)
    {
    }

    public DbSet<SneakerStore.Models.Brand> Brand { get; set; } = default!;

    public DbSet<SneakerStore.Models.Sneaker> Sneaker { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sneaker>()
            .HasOne(s => s.Brand)
            .WithMany(b => b.SneakerList)
            .HasForeignKey(s => s.BrandId);
        //.WillCascadeOnDelete(false);
    }
}
