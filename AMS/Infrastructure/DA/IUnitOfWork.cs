


using DA.Models.DomainModels;
using DA.Repositories.CommonRepositories;

namespace DA
{



    public interface IUnitOfWork
    {
        IGenericRepository<Allowance, string> allowanceRepo { get;  }
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
