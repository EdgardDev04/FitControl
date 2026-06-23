using FitControl.Application.Common;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Domain.Entities;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class AttendanceRepository : IAttendanceRepository
    {
        private readonly FitControlDbContext _context;

        public AttendanceRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
        }

        public async Task<bool> HasAnyActiveAttendanceAsync(int memberId)
        {
            return await _context.Attendances.AsNoTracking().AnyAsync(a => a.MemberId == memberId && a.CheckOutTime == null);
        }

        public async Task DeleteAsync(Attendance attendance)
        {
            _context.Attendances.Remove(attendance);
        }

        public async Task<ICollection<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Attendance>> GetAllByMemberIdAsync(int memberId)
        {
            return await _context.Attendances.AsNoTracking().Where(a => a.MemberId == memberId).ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task UpdateAsync(Attendance attendance) 
        {
            _context.Attendances.Update(attendance);
        }
        public async Task<Attendance> GetByMemberIdAsync(int memberId)
        {
            return await _context.Attendances.FirstOrDefaultAsync(a => a.MemberId == memberId);
        }

        public async Task<Attendance> GetActiveAttendanceAsync(int memberId) 
        {
            return await _context.Attendances.FirstOrDefaultAsync(a => a.MemberId == memberId && a.CheckOutTime == null);
        }

        public async Task<ICollection<Attendance>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Attendances.AsNoTracking().Where(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate).ToListAsync();
        }   

        public async Task<PagedResult<Attendance>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Attendances.Include(a => a.Member).AsNoTracking();

            if (!string.IsNullOrEmpty(paginationParams.Search))
            {
                var searchTerm = paginationParams.Search.Trim();

                if (DateTime.TryParse(searchTerm, out DateTime searchDate))
                {
                    query = query.Where(a => a.CheckInTime.Date == searchDate.Date ||
                                             (a.CheckOutTime.HasValue && a.CheckOutTime.Value.Date == searchDate.Date));
                }
                else
                {
                    query = query.Where(a => a.Member.FirstName.Contains(searchTerm) ||
                                             a.Member.LastName.Contains(searchTerm) ||
                                             a.Member.DocumentNumber.Contains(searchTerm));
                }
            }

            var sortBy = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sortBy switch
            {
                "CheckInTime" => paginationParams.Descending ? query.OrderByDescending(a => a.CheckInTime) : query.OrderBy(a => a.CheckInTime),
                "CheckOutTime" => paginationParams.Descending ? query.OrderByDescending(a => a.CheckOutTime) : query.OrderBy(a => a.CheckOutTime),
                "MemberName" => paginationParams.Descending ? query.OrderByDescending(a => a.Member.FirstName).ThenByDescending(a => a.Member.LastName) : query.OrderBy(a => a.Member.FirstName).ThenBy(a => a.Member.LastName),
                _ => query.OrderByDescending(a => a.CheckInTime)
            };

            var totalCount = await query.CountAsync();

            var attendances = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<Attendance>
            {
                Items = attendances,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }
    }
}
