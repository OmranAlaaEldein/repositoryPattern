using repositoryPattern.Models;
using repositoryPattern.Repositories.SchoolRepository;
using System;
using System.Threading.Tasks;

namespace repositoryPattern.Repositories
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private repositoryContext _context;
        public ISchoolRepository _schoolRepositoy { get; private set; }

        public UnitOfWork(repositoryContext context) {
            _context=context;
            _schoolRepositoy = new SchoolRepository.SchoolRepository(context);
        }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
