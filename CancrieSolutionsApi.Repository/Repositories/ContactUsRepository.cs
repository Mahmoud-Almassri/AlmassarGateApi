using AlmassarGate.Domain.Models;
using Repository.Context;
using Repository.Interfaces;
using Repository.Repositories.Common;

namespace Repository.Repositories
{
    public class ContactUsRepository : Repository<ContactUs>, IContactUsRepository
    {
        private AlmassarGateContext _context;

        public ContactUsRepository(
            AlmassarGateContext context
            ) : base(context)
        {
            _context = context;
        }
    }
}
