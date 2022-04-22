using Domains.Models;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private AlmassarGateContext _context;
        public RoleRepository(AlmassarGateContext context)
        {
            _context = context;
        }

        public Roles FirstOrDefault(Expression<Func<Roles, bool>> where)
        {
            Roles result = _context.Roles.FirstOrDefault(where);
            return result;
        }

        public IList<Roles> GetRoles()
        {
            List<Roles> roles = _context.Roles.ToList();
            return roles;
        }
    }
}
