using repositoryPattern.Models;

namespace repositoryPattern.Repositories.SchoolRepository
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(repositoryContext context) : base(context)  {}
    }
}
