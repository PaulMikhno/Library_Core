using Library.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public  class EFCoreGenericRopository<T>: IRepository<T> where T : class
    {
        private LibraryContext _dbContext;
        DbSet<T> _dbSet;

        public EFCoreGenericRopository(LibraryContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
        }

        public virtual void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            T item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }
        }

        public virtual IEnumerable<T> Get()
        {
            return _dbSet.ToList();
        }
    }
}

