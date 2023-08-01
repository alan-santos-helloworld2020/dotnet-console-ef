using Microsoft.EntityFrameworkCore;
using relacionamentos.Models;
using System;
using System.Collections.Generic;

namespace relacionamentos.Context
{
    public class FabricaContext : DbContext
    {
        public DbSet<Fabricante>? fabricantes { get; set; }
        public DbSet<Produto>? produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=banco.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fabricante>()
                .HasMany(e => e.produtos)
                .WithOne(e => e.fabricante)
                .HasForeignKey(e => e.FabricanteId)
                .IsRequired(false);
        }

    }



}