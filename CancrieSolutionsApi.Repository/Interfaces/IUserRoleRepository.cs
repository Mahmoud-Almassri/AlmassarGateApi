using AlmassarGate.Domain.DTO;
using AlmassarGateApi.Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IUserRoleRepository
    {
        UserRoles Add(UserRoles entity);
        IEnumerable<UserRoles> Find(Expression<Func<UserRoles, bool>> predicate, params Expression<Func<UserRoles, object>>[] navigationProperties);
        IList<RoleDTO> GetRoles();
        UserRoles FirstOrDefault(Expression<Func<UserRoles, bool>> where, params Expression<Func<UserRoles, object>>[] navigationProperties);
        public UserRolesDTO RemoveEmployeeRole(UserRolesDTO userRoles);
        public UserRolesDTO AddEmployeeRole(UserRolesDTO entity);
        public IList<UserResponseDTO> GetUsers();
        BaseListResponse<UserRoles> GetList(GroupSearch groupSearch);
    }
}
