﻿using AutoTradeHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace AutoTradeHub.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> cars { get; set; }
        public DbSet<Marka> marks { get; set; }
        public DbSet<Model> models { get; set; }
        public DbSet<Generation> generations { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Favorites> favorites { get; set; }
        public DbSet<Photo> photos { get; set; }

	}
}
