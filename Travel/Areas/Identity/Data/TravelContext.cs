﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Travel.Areas.Identity.Data;
using Travel.Models;
using Travel.Models.Entity;

namespace Travel.Areas.Identity.Data;

public class TravelContext : IdentityDbContext<TravelUser>
{
    public DbSet<Attraction> Attraction { get; set; }
    public DbSet<Journey> Journey { get; set; }
    public DbSet<Reservation> Reservation { get; set; }

    public TravelContext(DbContextOptions<TravelContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AppLicationUserEntityConfiguration());
    }
}

public class AppLicationUserEntityConfiguration : IEntityTypeConfiguration<TravelUser>
{
    public void Configure(EntityTypeBuilder<TravelUser> builder)
    {
    }
}