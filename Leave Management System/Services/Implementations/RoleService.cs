using AutoMapper;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Models;
using Leave_Management_System.Repositories.Interfaces;
using Leave_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Leave_Management_System.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRepository <Role> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;
        public RoleService(IRepository<Role> repository,IMapper mapper,ILogger<RoleService> logger){
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<RoleResponseDTO>> GetAllRoleAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.GetAll().OrderBy(r => r.RoleName)
            .Select(x => new RoleResponseDTO
            {
                RoleId = x.Id,
                RoleName = x.RoleName,
                Description = x.Description,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt ?? DateTime.UtcNow
            }).ToListAsync(cancellationToken);
        }
        public async Task<RoleResponseDTO?> GetRoleByIdAsync(long roleId, CancellationToken cancellationToken = default)
        {
            Role? role = await _repository.GetByIdAsync(roleId,cancellationToken);
            if(role == null)
            {
                return null;
            }
            return _mapper.Map<RoleResponseDTO>(role);
        }
        public async Task<RoleResponseDTO> CreateRoleAsync(CreateRoleRequestDTO role,CancellationToken cancellationToken = default)
        {
            bool exists = await _repository.ExistsAsync(r => r.RoleName == role.RoleName,cancellationToken);
            if(exists)
            {
                _logger.LogWarning("Role already exists with the name {RoleName}",role.RoleName);
                throw new Exception("Role already exists");
            }
            Role newrole = _mapper.Map<Role>(role);
            newrole.IsActive = true;
            await _repository.AddAsync(newrole,cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Role created successfully with the name {RoleName}",role.RoleName);
            return _mapper.Map<RoleResponseDTO>(newrole);
        }   
        public async Task<bool> UpdateRoleAsync(long roleId, UpdateRoleDTO role,CancellationToken cancellationToken = default)
        {
            Role? updatedRole = await _repository.GetByIdAsync(roleId,cancellationToken);
            if(updatedRole == null)
            {
                return false;
            }
            updatedRole.RoleName = role.RoleName;
            updatedRole.Description = role.Description;
            updatedRole.IsActive = role.IsActive;
            _repository.UpdateAsync(updatedRole);
            await _repository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Role updated successfully with the name {RoleId}",updatedRole.Id);
            return true;
        }
        public async Task<bool> DeleteRoleAsync(long roleId,CancellationToken cancellationToken = default)
        {
            await _repository.SoftDeleteAsync(roleId,cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Role Deleted Successfully with the {RoleId}",roleId);
            return true;
        }

    }
}
