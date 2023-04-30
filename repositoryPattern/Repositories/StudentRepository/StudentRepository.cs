using repositoryPattern.Models;

namespace repositoryPattern.Repositories.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        //D
        public StudentRepository(repositoryContext context) : base(context)
        {           }

    }
}
