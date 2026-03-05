using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using eVote360.Domain.Base;
using eVote360.Domain.Repositories;

namespace eVote360.Application
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}


