


using DA.Models.DomainModels;
using DA.Repositories.CommonRepositories;

namespace DA
{



    public interface IUnitOfWork
    {
        IGenericRepository<Allowance, string> allowanceRepo { get;  }
        IGenericRepository<WorkingProfile, string> workingProfileRepo { get; }
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
