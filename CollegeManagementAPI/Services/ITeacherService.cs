using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsyc();
        Task<Teacher> GetById(string id);
        Task CreateAsync(Teacher category);
        Task UpdateAsync(string id, Teacher category);
        Task DeleteAysnc(string id);
    }
}
