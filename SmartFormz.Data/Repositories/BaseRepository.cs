using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using SmartFormz.Business.Configuration;
using SmartFormz.Business.DataInterfaces;
using SmartFormz.Business.Models.Base;
using SmartFormz.Business.Models.Form;
using SmartFormz.Business.ResultModels;
using SmartFormz.Data.Infrastructure;

namespace SmartFormz.Data.Repositories
{
    public abstract class BaseRepository<T, IdT> : IDisposable, IRepository<T, IdT> where T: BaseModel
    {
        public SmartFormzContext DbContext { get; set; }

        protected BaseRepository()
        {
            var connectionString = ((SmartFormzConfiguration)ConfigurationManager.GetSection("smartFormzConfiguration")).ConnectionString;
            DbContext = new SmartFormzContext(connectionString);
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }

        public T Get(IdT id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(IdT id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public ICollection<T> Get()
        {
            return DbContext.Set<T>().ToList();
        }

        public async Task<List<T>> GetAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public SaveResult<T> Save(T model)
        {
            if (model.Id > 0)
            {
                var entry = DbContext.Set<T>().SingleOrDefault(x => x.Id == model.Id);
                DbContext.Entry(entry).CurrentValues.SetValues(model);
            }
            else
            {
                DbContext.Set<T>().Add(model);
            }
            try
            {
                DbContext.SaveChanges();
                return new SaveResult<T>(model, SaveResultStatus.Saved);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                //Deleted
                if (databaseEntry == null)
                {
                    return new SaveResult<T>(model, SaveResultStatus.RecordDeleted);
                }
                //Concurrency Exception
                var currentEntry = (T)databaseEntry.ToObject();
                model.RowVersion = currentEntry.RowVersion;

                return new SaveResult<T>(model, SaveResultStatus.ConcurrencyViolation, currentEntry);
            }
            catch (RetryLimitExceededException /* dex */)
            {
                return new SaveResult<T>(model, SaveResultStatus.Timeout);
            }
        }

        public async  Task<SaveResult<T>> SaveAsync(T model)
        {
            if (model.Id > 0)
            {
                var entry = DbContext.Set<T>().SingleOrDefault(x => x.Id == model.Id);
                DbContext.Entry(entry).CurrentValues.SetValues(model);
            }
            else
            {
                DbContext.Set<T>().Add(model);
            }
            try
            {
                await DbContext.SaveChangesAsync();
                return new SaveResult<T>(model, SaveResultStatus.Saved);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var databaseEntry = entry.GetDatabaseValues();
                //Deleted
                if (databaseEntry == null)
                {
                    return new SaveResult<T>(model, SaveResultStatus.RecordDeleted);
                }
                //Concurrency Exception
                var currentEntry = (T)databaseEntry.ToObject();
                model.RowVersion = currentEntry.RowVersion;

                return new SaveResult<T>(model, SaveResultStatus.ConcurrencyViolation, currentEntry);
            }
            catch (RetryLimitExceededException /* dex */)
            {
                return new SaveResult<T>(model, SaveResultStatus.Timeout);
            }
        }

        public void Delete(T model)
        {
            DbContext.Set<T>().Remove(model);
        }

    }
}
