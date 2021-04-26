﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VxTel.Domain.Contracts.Repositories;
using VxTel.Domain.Entities;
using VxTelApi.Data.Context;

namespace VxTelApi.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly VxTelContext _context;

        public Repository(VxTelContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Update(Guid id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
