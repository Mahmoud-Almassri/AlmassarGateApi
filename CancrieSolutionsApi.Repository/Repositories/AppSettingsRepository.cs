using AlmassarGate.Domain.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;

namespace Repository.Repositories
{
    public class AppSettingsRepository : Repository<AppSettings>, IAppSettingsRepository
    {
        private AlmassarGateContext _context;

        public AppSettingsRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
    }
}
