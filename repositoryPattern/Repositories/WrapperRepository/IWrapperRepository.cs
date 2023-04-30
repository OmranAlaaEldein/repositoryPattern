using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace repositoryPattern.Repositories.WrapperRepository
{
    public interface IWrapperRepository
    {
        SchoolRepository.ISchoolRepository SchoolRepository { get; }
        StudentRepository.IStudentRepository StudentRepository { get; }
        Task save();
    }
}
