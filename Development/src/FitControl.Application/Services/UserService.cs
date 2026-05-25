using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Application.Interfaces.Services;

namespace FitControl.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> ChangePasswordAsync(int userId, string password)
        {
            throw new NotImplementedException();
        }

        public Task CreateUserAsync(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UpdateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
