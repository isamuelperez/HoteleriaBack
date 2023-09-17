using HoteleriaBack.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Infrastructure.DataBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelContext _travelContext;
        public UnitOfWork(TravelContext travelContext)
        {
            _travelContext = travelContext;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_travelContext);
        }
        public void BeginTransaction()
        {
             _travelContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            //await _vecidadContext.SaveChangesAsync();
            try
            {
                _travelContext.SaveChanges();
                _travelContext.Database.CommitTransaction();
            }
            catch (Exception e)
            {
            }
        }

        public void Rollback()
        {
            _travelContext.Database.RollbackTransaction();
        }

    }
}
