using ProfilesWpf.Domain.Entities;
using ProfilesWpf.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfilesWpf.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateAsync(StudentForCreation studentForCreation);
        Task<bool> DeleteAsync(long id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetAsync(long id);
        Task<Student> UpdateAsync(long id, StudentForCreation studentForCreation);
        Task UploadImageAsync(long id, string imagePath, string passportPath);
    }
}
