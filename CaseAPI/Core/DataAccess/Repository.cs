using DevExpress.Xpo;

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

        public void Create(TEntity entity)
        {
            _uow.Save(entity);
        }
    }
}
