namespace DapperStudy.Domain.Interfaces.Repositories.Generico
{
    public interface IRepositorioGenerico<TEntity, Tid>
    {
        TEntity GetById(Tid id);

        IEnumerable<TEntity> GetAll();

        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}