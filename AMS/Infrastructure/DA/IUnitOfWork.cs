


using DA.Models.DomainModels;
using DA.Repositories.CommonRepositories;

namespace DA
{



    public interface IUnitOfWork
    {
        IGenericRepository<Allowance, string> allowanceRepo { get;  }
        IGenericRepository<WorkingProfile, string> workingProfileRepo { get; }
        IGenericRepository<Shift, string> shiftRepo { get; }

        IGenericRepository<Leave, string> leaveRepo { get; }
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken);
        Task CommitAsync();
    }
}
