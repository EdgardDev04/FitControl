using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class ClassTypeService : IClassTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateClassTypeAsync(CreateClassTypeDto dto)
        {
            var classType = _mapper.Map<ClassType>(dto);

            await _unitOfWork.ClassTypes.AddAsync(classType);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteClassTypeAsync(int classTypeId)
        {
            var classType = await _unitOfWork.ClassTypes.GetByIdAsync(classTypeId);

            if (classType == null) 
                throw new KeyNotFoundException($"ClassType with ID {classTypeId} not found.");

            await _unitOfWork.ClassTypes.DeleteAsync(classType);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassTypeDto>> GetAllClassTypesAsync()
        {
            var classType = await _unitOfWork.ClassTypes.GetAllAsync();

            if (classType == null) 
                return new List<ClassTypeDto>();

            return _mapper.Map<IEnumerable<ClassTypeDto>>(classType);
        }

        public async Task<ClassTypeDto?> GetClassTypeByIdAsync(int classTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateClassTypeAsync(int classTypeId, UpdateClassTypeDto dto)
        {
            var classType = await _unitOfWork.ClassTypes.GetByIdAsync(classTypeId);

            if (classType == null) 
                throw new KeyNotFoundException();

            _mapper.Map(classType, dto);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
