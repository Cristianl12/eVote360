using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eVote360.Application; // <- IMPLEMENTA la interfaz de Application
using eVote360.Domain.Base;
using eVote360.Domain.Repositories;
using eVote360.Persistence.Context;

namespace eVote360.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            return new BaseRepository<TEntity>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}


