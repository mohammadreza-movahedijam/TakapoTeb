﻿using Application.Contract;
using Infrastructure.Configuration.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Implement;

public class ContextRepository(SqlServerContext context) : IContext
{
    private SqlServerContext _context = context;
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }
    public IExecutionStrategy CreateExecutionStrategy()
    {
        return _context.Database.CreateExecutionStrategy();
    }
    public void ClearTracker()
    {
        _context.ChangeTracker.Clear();
    }

    public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
    {
        return _context.Set<TEntity>().AsQueryable();
    }

}