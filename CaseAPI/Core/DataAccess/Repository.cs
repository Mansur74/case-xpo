using DevExpress.Xpo;
using System.Linq.Expressions;

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

        public void Delete(TEntity entity)
        {

            _uow.Delete(entity);
            _uow.CommitChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = new XPQuery<TEntity>(_uow).SingleOrDefault(filter);
            return entity;
        }

        public TEntity CreateObject()
        {
            TEntity entity = (TEntity) Activator.CreateInstance(typeof(TEntity), _uow);
            return entity;

        }
    }
}
