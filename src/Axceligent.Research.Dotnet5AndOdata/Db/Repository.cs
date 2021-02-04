using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace Research.Dotnet5AndOdata.Db
{
    public class Repository<T> : IRepository<T> where T : class {

        public ChangeTracker ChangeTracker => Context.ChangeTracker;
        protected DbContext Context { get; }
        protected DbSet<T> DbSet { get; }

        public Repository(DbContext context) {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public ValueTask<EntityEntry<T>> Add(T entity) {
            return DbSet.AddAsync(entity);
        }

        public Task AddRange(IEnumerable<T> entity) {
            return DbSet.AddRangeAsync(entity);
        }

        public EntityEntry<T> Attach(T entity) {
            return DbSet.Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entity) {
            DbSet.AttachRange(entity);
        }

        public IDbContextTransaction BeginTransaction() {
            return Context.Database.BeginTransaction();
        }

        public async Task DeleteAll() {
            if (await Query().AnyAsync()) {
                DbSet.RemoveRange(Query());
            }
        }

        public void DetachAllEntities() {
            var changedEntriesCopy = ChangeTracker.Entries()
                                                  .Where(e => e.State == EntityState.Added ||
                                                              e.State == EntityState.Modified ||
                                                              e.State == EntityState.Deleted)
                                                  .ToList();

            foreach (var entity in changedEntriesCopy) {
                Context.Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public string GetTableName() {
            return FindTableEntity().GetTableName();
        }

        public IEntityType FindTableEntity() {
            return Context.Model.FindEntityType(typeof(T));
        }

        public EntityEntry<T> Entry(T entity) {
            return Context.Entry(entity);
        }

        public DbContext GetContext() {
            return Context;
        }

        public DbSet<T> Query() {
            return DbSet;
        }

        public void Remove(T entity) {
            ChangeTrackerForSofDelete();
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) {
            ChangeTrackerForSofDelete();
            DbSet.RemoveRange(entities);
        }

        public Task<int> SaveChanges() {
            return Context.SaveChangesAsync();
        }

        public void Update(T entity) {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities) {
            DbSet.UpdateRange(entities);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync() {
            return GetContext().Database.BeginTransactionAsync();
        }


        private void ChangeTrackerForSofDelete() {

            //todo 2805- this should move to soft delete related files.
            // #Core3BreakingChange
            // https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-3.0/breaking-changes#cascade
            // Disabling the ReSharper error (not going to make the class sealed for now) as this is a temporary hotfix
            // TODO: https://axceligent.visualstudio.com/PPMS/_workitems/edit/2280

            // ReSharper disable once VirtualMemberCallInConstructor
            Context.ChangeTracker.CascadeDeleteTiming = CascadeTiming.OnSaveChanges;

            // ReSharper disable once ArrangeThisQualifier
            Context.ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
        }

    }

    public interface IRepository<T> where T : class {

        DbSet<T> Query();

        EntityEntry<T> Entry(T entity);

        ValueTask<EntityEntry<T>> Add(T entity);

        Task AddRange(IEnumerable<T> entity);

        EntityEntry<T> Attach(T entity);
        void AttachRange(IEnumerable<T> entity);

        IDbContextTransaction BeginTransaction();

        Task<int> SaveChanges();

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task DeleteAll();

        DbContext GetContext();

        Task<IDbContextTransaction> BeginTransactionAsync();

        void DetachAllEntities();

        IEntityType FindTableEntity();

        string GetTableName();

        //string GetTableColumnName(Expression<Func<T, object>> property);

    }

}