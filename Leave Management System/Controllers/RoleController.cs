using Leave_Management_System.Common;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRoleAsync();
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Roles Retrieved Successfully",
                Data = roles
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(long id)
        {
            var roleData = await _roleService.GetRoleByIdAsync(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Role Retrieved successfully for the role id"+roleData?.RoleId,
                Data = roleData
            });
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(CreateRoleRequestDTO dto)
        {
            var newRoleData = await _roleService.CreateRoleAsync(dto);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Role Created Successfully",
                Data = newRoleData   
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleAsync(long id, UpdateRoleDTO dto)
        {
            var isUpdated = await _roleService.UpdateRoleAsync(id, dto);
            if(!isUpdated)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "The data for the corresponding roleId is not found",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Role Updated Successfully",
                Data = null
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleAsync(long id)
        {
            var isDeleted = await _roleService.DeleteRoleAsync(id);
            if (!isDeleted)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "The data for the corresponding roleId is not found",
                    Data = null
                });
            }
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Role Deleted Successfully",
                Data = null
            });
        }
    }
}
