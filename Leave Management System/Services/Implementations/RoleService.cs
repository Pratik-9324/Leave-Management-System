using AutoMapper;
using Leave_Management_System.DTOs.Roles;
using Leave_Management_System.Models;
using Leave_Management_System.Repositories.Interfaces;
using Leave_Management_System.Services.Interfaces;

namespace Leave_Management_System.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository,IMapper mapper){
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleResponseDTO>> GetAllRoleAsync()
        {
            var roleData = await _roleRepository.GetAllAsync();
            var roleResponse = _mapper.Map<IEnumerable<RoleResponseDTO>>(roleData);
            return roleResponse;
        }
        public async Task<RoleResponseDTO?> GetRoleByIdAsync(long roleId)
        {
            var roleData = await _roleRepository.GetByIdAsync(roleId);
            if(roleData == null)
            {
                return null;
            }
            var roleResponse = _mapper.Map<RoleResponseDTO>(roleData);
            return roleResponse;
        }
        public async Task<RoleResponseDTO> CreateRoleAsync(CreateRoleRequestDTO role)
        {
            var existingRole = await _roleRepository.GetByNameAsync(role.RoleName);
            if(existingRole != null)
            {
                throw new Exception("Role Already exists");
            }
            var newRole = _mapper.Map<Role>(role);
            await _roleRepository.AddAsync(newRole);
            await _roleRepository.SaveChangesAsync();
            return _mapper.Map<RoleResponseDTO>(newRole);
        }
        public async Task<bool> UpdateRoleAsync(long roleId, UpdateRoleDTO role)
        {
            var existingRole = await _roleRepository.GetByIdAsync(roleId);
            if(existingRole == null)
            {
                return false;
            }   
            existingRole.RoleName = role.RoleName;
            existingRole.Description = role.Description;
            existingRole.IsActive = role.IsActive;
            _roleRepository.UpdateAsync(existingRole);
            await _roleRepository.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRoleAsync(long roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            if(role == null)
            {
                return false;
            }
            _roleRepository.DeleteAsync(role);
            await _roleRepository.SaveChangesAsync();
            return true;
        }

    }
}
