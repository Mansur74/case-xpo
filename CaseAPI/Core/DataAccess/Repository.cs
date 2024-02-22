using DevExpress.Xpo;
using System.Linq.Expressions;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace CaseAPI.Core.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        UnitOfWork _uow;
        public Repository(UnitOfWork uow)
        {
            _uow = uow;
        }
        public ICollection<TEntity> GetAll()
        {
            ICollection<TEntity> result = _uow.Query<TEntity>().ToList();
            return result;
        }

        public void Add(TEntity entity)
        {
            _uow.Save(entity);
            _uow.CommitChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = new XPQuery<TEntity>(_uow).FirstOrDefault(filter);
            _uow.Delete(entity);
            _uow.CommitChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = new XPQuery<TEntity>(_uow).FirstOrDefault(filter);
            return entity;
        }
    }
}
