using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IClassTypeService
    {
        Task CreateClassTypeAsync(CreateClassTypeDto dto);

        Task UpdateClassTypeAsync(int classTypeId, UpdateClassTypeDto dto);

        Task DeleteClassTypeAsync(int classTypeId);

        Task<ClassTypeDto?> GetClassTypeByIdAsync(int classTypeId);

        Task<IEnumerable<ClassTypeDto>> GetAllClassTypesAsync();
    }
}
