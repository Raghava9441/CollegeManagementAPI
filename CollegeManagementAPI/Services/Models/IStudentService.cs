using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Services.Models
{
    public interface IStudentService
    {
            Task<IEnumerable<Student>> GetAllAsyc();
            Task<Student> GetById(string id);
            Task CreateAsync(Student student);
            Task UpdateAsync(string id, Student student);
            Task DeleteAysnc(string id);
    }
}
