using AlmassarGate.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWebUserService
    {

        Task<UserProfileResponseDTO> GetWebUserProfile();
        Task<UserProfileResponseDTO> UpdateWebUserProfile(UserProfileRequestDTO userProfile);
    }
}
