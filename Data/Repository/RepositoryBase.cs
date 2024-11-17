using Data.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DatabaseContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return  _dbSet.Find(id);
        }

        public int? Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                SaveChanges();

                var idProperty = typeof(T).GetProperty("Id");
                if (idProperty != null)
                {
                    return (int?)idProperty.GetValue(entity);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add failed: {ex.Message}");
                return null;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update failed: {ex.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete failed: {ex.Message}");
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SaveChanges failed: {ex.Message}");
                return false;
            }
        }
    }
}
