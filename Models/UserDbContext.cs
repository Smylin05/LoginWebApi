﻿using Microsoft.EntityFrameworkCore;

namespace LoginWebApi.Models
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
    }
}
