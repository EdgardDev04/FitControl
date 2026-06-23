using AutoMapper;
using FitControl.Application.Common;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Entities;

namespace FitControl.Application.Services
{
    internal class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AssignRoleToUserAsync(int userId, int roleId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            var role = await _unitOfWork.Roles.GetByIdAsync(roleId);

            if (user == null || role == null)
            {
                throw new KeyNotFoundException("User or Role not found");
            }

            if (await _unitOfWork.UserRoles.UserHasRoleAsync(userId, roleId))
            {
                throw new InvalidOperationException("User already has this role");
            }

            var userRole = new UserRole(user.Id, role.Id);

            await _unitOfWork.UserRoles.AddAsync(userRole);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<RoleDto> CreateAsync(string name)
        {
            var existingRole = await _unitOfWork.Roles.GetByNameAsync(name);
            
            if (existingRole != null)
            {
                throw new InvalidOperationException("Role already exists");
            }

            var role = new Role(name);

            await _unitOfWork.Roles.AddAsync(role);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<RoleDto>(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var roleWithUsers = await _unitOfWork.Roles.GetByIdAsync(id);

            if (roleWithUsers != null)
            {
                throw new Exception("Role cannot be deleted, because it is in use");
            }

            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
            {
                throw new KeyNotFoundException("Role not found");
            }

            await _unitOfWork.Roles.DeleteAsync(role);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<RoleDto>> GetAllRoleAsync()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();

            if (roles == null)
            {
                return new List<RoleDto>();
            }

            return _mapper.Map<ICollection<RoleDto>>(roles);
        }

        public async Task<RoleDto?> GetByNameAsync(string roleName)
        {
            var role = await _unitOfWork.Roles.GetByNameAsync(roleName);

            if (role == null)
            {
                return null;
            }

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<PagedResult<RoleDto>> GetPagedRolesAsync(PaginationParams paginationParams)
        {
            var pagedRoles = await _unitOfWork.Roles.GetPagedAsync(paginationParams);

            return new PagedResult<RoleDto>
            {
                Items = _mapper.Map<IEnumerable<RoleDto>>(pagedRoles.Items),
                PageNumber = pagedRoles.PageNumber,
                PageSize = pagedRoles.PageSize,
                TotalCount = pagedRoles.TotalCount,
                TotalPages = pagedRoles.TotalPages
            };
        }

        public async Task<RoleDto?> GetRoleAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
            {
                return null;
            }

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<bool> RemoveRoleFromUserAsync(int userId, int roleId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            var role = await _unitOfWork.Roles.GetByIdAsync(roleId);

            if (user == null || role == null)
            {
                throw new KeyNotFoundException("User or Role not found");
            }

            var hasRole = await _unitOfWork.UserRoles.UserHasRoleAsync(userId, roleId);

            if (!hasRole)
            {
                throw new InvalidOperationException("User does not have this role");
            }

            await _unitOfWork.UserRoles.DeleteAsync(userId, roleId);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task UpdateRoleAsync(int id, string name)
        {
            var existingRole = await _unitOfWork.Roles.GetByNameAsync(name);

            if (existingRole == null)
            {
                throw new InvalidOperationException("Role already exists");
            }

            var role = await _unitOfWork.Roles.GetByIdAsync(id);

            if (role == null)
            {
                throw new KeyNotFoundException("Role not found");
            }

            role.Update(name);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
