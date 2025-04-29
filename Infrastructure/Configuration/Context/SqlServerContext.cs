﻿using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Configuration.Context;


public class SqlServerContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.HasSequence<long>("CodeGenerator")
         .StartsAt(10000).IncrementsBy(2).HasMax(long.MaxValue);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.AppendDbSetOfEntity();
        base.OnModelCreating(builder);
    }
}