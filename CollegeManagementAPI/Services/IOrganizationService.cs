using CollegeManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementAPI.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllAsyc();
        Task<Organization> GetById(string id);
        Task CreateAsync(Organization category);
        Task UpdateAsync(string id, Organization category);
        Task DeleteAysnc(string id);
    }
}