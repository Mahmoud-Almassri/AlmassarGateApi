using AlmassarGate.Domain.DTO;
using AutoMapper;
using Domains.Models;
using Microsoft.AspNetCore.Identity;
using Repository.UnitOfWork;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WebUserService : IWebUserService
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private LoggedInUserService _loggedInUserService;
        private IMapper _mapper;
        public WebUserService(UserManager<ApplicationUser> userManager, IRepositoryUnitOfWork repositoryUnitOfWork, LoggedInUserService loggedInUserService, IMapper mapper)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
            _userManager = userManager;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<UserProfileResponseDTO> GetWebUserProfile()
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            UserProfileResponseDTO userProfileDTO = _mapper.Map<UserProfileResponseDTO>(user);
            return userProfileDTO;
        }

        public async Task<UserProfileResponseDTO> UpdateWebUserProfile(UserProfileRequestDTO userProfile)
        {
            long userId = _loggedInUserService.GetUserId();
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            user.Email = userProfile.Email;
            user.PhoneNumber = userProfile.PhoneNumber;
            user.FullName = userProfile.FullName;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return _mapper.Map<UserProfileResponseDTO>(user); ;
            }
            throw new Exception("Error in Updating User Info");
        }
    }
}
