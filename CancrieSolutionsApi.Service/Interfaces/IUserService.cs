using AlmassarGate.Domain.DTO;
using AlmassarGateApi.Domain.SearchModels;
using Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> Register(RegisterDTO model);
        Task<UserResponseDTO> UpdateUserInfo(UserRequestDTO userInfo);
        Task<bool> RemoveUser(int userId);
        Task<ListResponse<UserResponseDTO>> GetUsersList(UserSearchModel search);
        Task<UserResponseDTO> GetUserInfo(int userId);
        Task<UserProfileResponseDTO> GetUserProfile();
        Task<UserProfileResponseDTO> UpdateUserProfile(UserProfileRequestDTO userProfile);
        IList<RoleDTO> GetRoles();
        IList<UserResponseDTO> GetUsers();
        UserRolesDTO AddUserGroup(UserRolesDTO userRole);
        UserRolesDTO RemoveUserRole(UserRolesDTO userRoles);
        BaseListResponse<UserRoles> GetList(GroupSearch groupSearch);
        IEnumerable<RoleDTO> GetBaseRoles();
    }
}


