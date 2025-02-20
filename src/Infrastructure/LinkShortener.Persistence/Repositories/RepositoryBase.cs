﻿using System.Linq.Expressions;
using LinkShortener.Domain.Entities;
using LinkShortener.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
{
    private readonly RepositoryContext _context;
    
    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }
    
    public async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }
    
    public IQueryable<T> FindAll(bool trackChanges)
    {
        if (trackChanges)
        {
            return _context.Set<T>();
        }

        return _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (trackChanges)
        {
            return _context.Set<T>().Where(expression);
        }

        return _context.Set<T>().Where(expression).AsNoTracking();
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}