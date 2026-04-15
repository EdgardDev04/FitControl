using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class ClassSessionService : IClassSessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassSessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CancelSessionAsync(int sessionId)
        {
            var session = await _unitOfWork.ClassSessions.GetByIdAsync(sessionId);

            if (session == null) 
                throw new Exception();

            session.MarkAsCancelled();

            await _unitOfWork.SaveChangesAsync();

        }

        public async Task CreateSessionAsync(CreateClassSessionDto dto)
        {
            var session = _mapper.Map<ClassSession>(dto);

            await _unitOfWork.ClassSessions.AddAsync(session);

            await _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<ClassSessionDto>> GetAvailableSessionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ClassSessionDto?> GetSessionByIdAsync(int sessionId)
        {
            var session = await _unitOfWork.ClassSessions.GetByIdAsync(sessionId);

            if (session == null)
                return null;

            return _mapper.Map<ClassSessionDto>(session);
        }

        public async Task<IEnumerable<ClassSessionDto>> GetSessionsByClassTypeAsync(int classTypeId)
        {
            var sessions = await _unitOfWork.ClassSessions.GetAllByClassTypeIdAsync(classTypeId);

            if (sessions == null)
                return new List<ClassSessionDto>();

            return _mapper.Map<IEnumerable<ClassSessionDto>>(sessions);
        }

        public async Task<ClassSessionDto> GetSessionsByDateAsync(DateTime date)
        {
            var session = await _unitOfWork.ClassSessions.GetByDateAsync(date);

            if (session == null)
                throw new Exception();

            return _mapper.Map<ClassSessionDto>(session);
        }

        public async Task<IEnumerable<ClassSessionDto>> GetSessionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var sessions = _unitOfWork.ClassSessions.GetByDateRangeAsync(startDate, endDate);

            if (sessions == null)
                return new List<ClassSessionDto>();

            return _mapper.Map<IEnumerable<ClassSessionDto>>(sessions);
        }

        public async Task<IEnumerable<ClassSessionDto>> GetSessionsByInstructorAsync(int instructorId)
        {
            var sessions = await _unitOfWork.ClassSessions.GetAllByTrainerIdAsync(instructorId);

            if (sessions == null)
                return new List<ClassSessionDto>();

            return _mapper.Map<IEnumerable<ClassSessionDto>>(sessions);
        }

        public async Task UpdateSessionAsync(int sessionId, UpdateClassSessionDto dto)
        {
            var session = _unitOfWork.ClassSessions.GetByIdAsync(sessionId);

            if (session == null)
                throw new KeyNotFoundException();

            _mapper.Map(session, dto);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
