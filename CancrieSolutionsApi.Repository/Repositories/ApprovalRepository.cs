using AlmassarGateApi.Repository.Interfaces;
using Domains.Models;
using Repository.Context;
using Repository.Repositories.Common;
using System.Linq;

namespace AlmassarGateApi.Repository.Repositories
{
    public class ApprovalRepository : Repository<Approval>, IApprovalRepository
    {
        private AlmassarGateContext _context;
        public ApprovalRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
       
    }
}
