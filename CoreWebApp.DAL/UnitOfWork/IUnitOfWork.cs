using CoreWebApp.DAL.DbSets;
using CoreWebApp.DAL.GenericRepository;

namespace CoreWebApp.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();
        IGenericRepository<Categories> CategoriesRepo { get; }
    }
}