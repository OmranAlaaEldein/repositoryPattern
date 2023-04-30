using Microsoft.AspNetCore.Authentication;
using repositoryPattern.Models;
using repositoryPattern.Repositories.SchoolRepository;
using repositoryPattern.Repositories.StudentRepository;
using System.Threading.Tasks;

namespace repositoryPattern.Repositories.WrapperRepository
{
    public class WrapperRepository: IWrapperRepository
    {
        private repositoryContext _context;
        private ISchoolRepository _SchoolRepository { get; set; }
        private IStudentRepository _StudentRepository { get; set; }


        public WrapperRepository(repositoryContext context)
        {
            _context = context;
        }

        public ISchoolRepository SchoolRepository {
            get
            {
                if (_SchoolRepository == null)
                {
                    _SchoolRepository = new SchoolRepository.SchoolRepository(_context);
                }
                return _SchoolRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_StudentRepository == null)
                {
                    _StudentRepository = new StudentRepository.StudentRepository(_context);
                }
                return _StudentRepository;
            }
        }

        
        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
