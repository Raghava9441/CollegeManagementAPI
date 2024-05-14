using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Services.Models
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsyc();
        Task<Teacher> GetById(string id);
        Task CreateAsync(Teacher teacher);
        Task UpdateAsync(string id, Teacher teacher);
        Task DeleteAysnc(string id);
    }
}
