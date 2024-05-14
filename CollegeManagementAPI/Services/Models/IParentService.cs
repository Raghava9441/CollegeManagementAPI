using CollegeManagementAPI.Models;

namespace CollegeManagementAPI.Services.Models
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>> GetAllAsyc();
        Task<Parent> GetById(string id);
        Task CreateAsync(Parent org);
        Task UpdateAsync(string id, Parent org);
        Task DeleteAysnc(string id);
    }
}
