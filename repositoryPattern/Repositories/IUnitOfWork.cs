using repositoryPattern.Repositories.SchoolRepository;
using System.Threading.Tasks;

namespace repositoryPattern.Repositories
{
    public interface IUnitOfWork
    {
        ISchoolRepository _schoolRepositoy { get; }
        Task save();    
    }
}
