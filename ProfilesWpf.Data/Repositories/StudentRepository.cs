using ProfilesWpf.Data.IRepositories;
using ProfilesWpf.Domain.Entities;

namespace ProfilesWpf.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
    }
}
