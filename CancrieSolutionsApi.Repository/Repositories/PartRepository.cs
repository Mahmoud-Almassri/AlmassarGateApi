using AlmassarGateApi.Domain.Models;
using AlmassarGateApi.Repository.Interfaces;
using Repository.Context;
using Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmassarGateApi.Repository.Repositories
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        private AlmassarGateContext _context;
        public PartRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
    }
}
