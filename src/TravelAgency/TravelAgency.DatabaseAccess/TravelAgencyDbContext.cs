﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DatabaseAccess.Enitities.Identity;
using TravelAgency.DatabaseAccess.Enitities.Users;
using TravelAgency.DatabaseAccess.Entities;
using TravelAgency.DatabaseAccess.Interfaces;

namespace TravelAgency.DatabaseAccess
{
    internal class TravelAgencyDbContext : IdentityDbContext<User, IdentityRole<int>, int>, ITravelAgencyDbContext
    {
        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Ignore(u => u.AccessFailedCount)
                                  .Ignore(u => u.NormalizedUserName)
                                  .Ignore(u => u.PhoneNumber)
                                  .Ignore(u => u.PhoneNumberConfirmed)
                                  .Ignore(u => u.TwoFactorEnabled);

            builder.Entity<Order>().HasKey(u => u.Id);
            builder.Entity<Manager>().HasKey(u => u.UserId);
            builder.Entity<Offer>().HasKey(u => u.Id);
            builder.Entity<Review>().HasKey(u => u.Id);
            builder.Entity<Session>().HasKey(u => u.Id);
            builder.Entity<Order>().HasKey(u => u.Id);
            builder.Entity<Session>().HasKey(u => u.Id);
            builder.Entity<Subscriber>().HasKey(u => u.Id);
            builder.Entity<News>().HasKey(u => u.Id);
            builder.Entity<RegisteredUser>().HasKey(u => u.UserId);
        }
    }
}
