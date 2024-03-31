﻿using Microsoft.EntityFrameworkCore;
using studentManagementSystem.Models;

namespace studentManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }



       
    }
}
