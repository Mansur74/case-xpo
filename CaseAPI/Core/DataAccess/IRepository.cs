namespace CaseAPI.Core.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public ICollection<TEntity> GetAll();
        public void Create(TEntity entity);
    }
}
