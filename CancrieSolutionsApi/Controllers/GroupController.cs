using AlmassarGate.Domain.DTO;
using AlmassarGateApi.Domain.SearchModels;
using Domain.SearchModels;
using Domains.DTO;
using Domains.Models;
using Domains.SearchModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlmassarGateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public GroupController(IServiceUnitOfWork serviceUnitOfWork)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUserRoles()
        {
            try
            {
                IEnumerable<RoleDTO> Part = _serviceUnitOfWork.User.Value.GetRoles();
                return Ok(Part);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            var usersList =  _serviceUnitOfWork.User.Value.GetUsers();
            return Ok(usersList);
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddUserGroup(UserRolesDTO userRole)
        {
            _serviceUnitOfWork.User.Value.AddUserGroup(userRole);
            return Ok(userRole);
        }
 
        [HttpPost]
        [Authorize]
        public IActionResult GetList([FromBody] GroupSearch groupSearch)
        {
            try
            {
                BaseListResponse<UserRoles> UserRolesList = _serviceUnitOfWork.User.Value.GetList(groupSearch);
                return Ok(UserRolesList);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult RemoveUserRole(UserRolesDTO userRoles)
        {
            try
            {
                _serviceUnitOfWork.User.Value.RemoveUserRole(userRoles);
                return Ok(true);
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}
