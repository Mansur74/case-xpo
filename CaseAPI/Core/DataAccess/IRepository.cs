using System.Linq.Expressions;

namespace CaseAPI.Core.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public ICollection<TEntity> GetAll();
        public TEntity Get(Expression<Func<TEntity, bool>> filter);
        public void Delete(TEntity entity);
        public void Save();
        public TEntity CreateObject();
    }
}
