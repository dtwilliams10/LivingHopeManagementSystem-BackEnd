using System.Collections.Generic;
using System.Threading.Tasks;

namespace LHMSAPI.Models
{
    public interface ISystemReportRepository
    {
        Task<IEnumerable<SystemReport>> GetAllSystemReports();
        Task<SystemReport> GetSystemReport(string id);

        Task AddSystemReport(SystemReport systemReport);

        Task<bool> RemoveSystemReport(string id);

        Task<bool> UpdateSystemReport(string id, string body);
    }
}
