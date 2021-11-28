﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class TvProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TvProjectDb;integrated security=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Tv> Tvs { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<TvBrand> TvBrands { get; set; }
        public DbSet<TvPhoto> TvPhotos { get; set; }
    }
}
