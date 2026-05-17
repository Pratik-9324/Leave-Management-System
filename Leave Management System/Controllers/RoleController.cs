using Leave_Management_System.Common;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;

    private readonly ILogger<RoleController>
        _logger;

    public RoleController(
        IRoleService service,
        ILogger<RoleController> logger)
    {
        _service = service;

        _logger = logger;
    }

    // =========================================
    // GET ALL ROLES
    // =========================================

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        IEnumerable<RoleResponseDTO> roles =
            await _service.GetAllRoleAsync(
                cancellationToken);

        return Ok(new ApiResponse<
            IEnumerable<RoleResponseDTO>>
        {
            Success = true,
            Message = "Roles fetched successfully.",
            Data = roles
        });
    }

    // =========================================
    // GET ROLE BY ID
    // =========================================

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(
        long id,
        CancellationToken cancellationToken)
    {
        RoleResponseDTO? role =
            await _service.GetRoleByIdAsync(
                id,
                cancellationToken);

        if (role == null)
        {
            return NotFound(
                new ApiResponse<string>
                {
                    Success = false,
                    Message = "Role not found."
                });
        }

        return Ok(new ApiResponse<RoleResponseDTO>
        {
            Success = true,
            Message = "Role fetched successfully.",
            Data = role
        });
    }

    // =========================================
    // CREATE ROLE
    // =========================================

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateRoleRequestDTO dto,
        CancellationToken cancellationToken)
    {
        RoleResponseDTO role =
            await _service.CreateRoleAsync(
                dto,
                cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = role.RoleId },
            new ApiResponse<RoleResponseDTO>
            {
                Success = true,
                Message = "Role created successfully.",
                Data = role
            });
    }

    // =========================================
    // UPDATE ROLE
    // =========================================

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(
        long id,
        [FromBody] UpdateRoleDTO dto,
        CancellationToken cancellationToken)
    {
        bool updated =
            await _service.UpdateRoleAsync(
                id,
                dto,
                cancellationToken);

        if (!updated)
        {
            return NotFound(
                new ApiResponse<string>
                {
                    Success = false,
                    Message = "Role not found."
                });
        }

        return Ok(new ApiResponse<string>
        {
            Success = true,
            Message = "Role updated successfully."
        });
    }

    // =========================================
    // DELETE ROLE
    // =========================================

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(
        long id,
        CancellationToken cancellationToken)
    {
        bool deleted =
            await _service.DeleteRoleAsync(
                id,
                cancellationToken);

        if (!deleted)
        {
            return NotFound(
                new ApiResponse<string>
                {
                    Success = false,
                    Message = "Role not found."
                });
        }

        return Ok(new ApiResponse<string>
        {
            Success = true,
            Message = "Role deleted successfully."
        });
    }
}