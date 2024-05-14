using CollegeManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementAPI.Services.Models
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllAsyc();
        Task<Organization> GetById(string id);
        Task CreateAsync(Organization org);
        Task UpdateAsync(string id, Organization org);
        Task DeleteAysnc(string id);
    }
}