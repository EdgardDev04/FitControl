using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces
{
    public interface IClassSessionService
    {
        Task CreateSessionAsync(CreateClassSessionDto dto);

        Task UpdateSessionAsync(int sessionId, UpdateClassSessionDto dto);

        Task CancelSessionAsync(int sessionId);

        Task<ClassSessionDto?> GetSessionByIdAsync(int sessionId);

        Task<ClassSessionDto> GetSessionsByDateAsync(DateTime date);

        Task<IEnumerable<ClassSessionDto>> GetSessionsByDateRangeAsync(DateTime startDate, DateTime endDate);

        Task<IEnumerable<ClassSessionDto>> GetSessionsByClassTypeAsync(int classTypeId);

        Task<IEnumerable<ClassSessionDto>> GetSessionsByInstructorAsync(int instructorId);

        Task<IEnumerable<ClassSessionDto>> GetAvailableSessionsAsync();
    }
}
