using LHMSAPI.Helpers;

namespace LHMSAPI.Services
{
    public interface ISystemReportService
    {

    }

    public class SystemReportService : ISystemReportService
    {
        private readonly DatabaseContext _context;

        public SystemReportService(DatabaseContext context)
        {
            _context = context;
        }
    }
}