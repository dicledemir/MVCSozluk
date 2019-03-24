using DAL;
using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace BLL
{
    public class BaseRepository<T, TKey> where T : class
    {
        private SozlukContext _db;

        public BaseRepository(SozlukContext db)
        {
            _db = db;
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> Search(Func<T,bool> query)
        {
            return _db.Set<T>().Where(query).ToList();
        }
        
        public IQueryable<T> Queryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public T GetOne(TKey id)
        {
            return _db.Set<T>().Find(id);
        }

        public bool Add(T record)
        {
            try
            {
                _db.Set<T>().Add(record);
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public virtual bool Delete(TKey id)
        {
            try
            {
                T t = GetOne(id);
                _db.Set<T>().Remove(t);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(IEntity newRecord)
        {
            try
            {
                object id = newRecord.Id;
                T old = GetOne((TKey)id);
                _db.Entry(old).CurrentValues.SetValues(newRecord);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
