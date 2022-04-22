using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        Roles FirstOrDefault(Expression<Func<Roles, bool>> where);
        IList<Roles> GetRoles();
    }
}
