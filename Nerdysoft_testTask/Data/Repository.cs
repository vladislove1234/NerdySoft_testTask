using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nerdysoft_testTask.Data.Interfaces;
using Nerdysoft_testTask.Model.Abstraction;

namespace Nerdysoft_testTask.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataBaseContext _context;
        public Repository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _context.Set<T>().Where(entity => entity.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<T> Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
