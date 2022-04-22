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
    public class ProjectFileRepository : Repository<ProjectFiles>, IProjectFileRepository
    {
        private AlmassarGateContext _context;
        public ProjectFileRepository(AlmassarGateContext context) : base(context)
        {
            _context = context;
        }
    }
}
