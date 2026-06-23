using FitControl.Application.Common;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class MembershipRepository : IMembershipRepository
    {
        private readonly FitControlDbContext _context;

        public MembershipRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Membership membership)
        {
            await _context.Memberships.AddAsync(membership);
        }

        public async Task<bool> AnyActiveByMembershipPlanIdAsync(int membershipPlanId)
        {
            return await _context.Memberships.AsNoTracking().AnyAsync(m => m.MembershipPlanId == membershipPlanId && m.Status == MembershipStatus.Active);
        }

        public async Task<bool> AnyActiveByMemberIdAsync(int memberId)
        {
            return await _context.Memberships.AsNoTracking().AnyAsync(m => m.MemberId == memberId && m.Status == MembershipStatus.Active);
        }

        public async Task DeleteAsync(Membership membership)
        {
            _context.Memberships.Remove(membership);
        }

        public async Task<ICollection<Membership>> GetAllAsync() 
        { 
            return await _context.Memberships.AsNoTracking().ToListAsync(); 
        }
        public async Task<ICollection<Membership>> GetAllByDateAsync(DateTime startdate, DateTime enddate) 
        { 
            return await _context.Memberships.AsNoTracking().Where(m => m.StartDate >= startdate && m.EndDate <= enddate).ToListAsync(); 
        }

        public async Task<ICollection<Membership>> GetAllByStatusAsync(MembershipStatus status)
        { 
            return await _context.Memberships.AsNoTracking().Where(m => m.Status == status).ToListAsync(); 
        }

        public async Task<Membership?> GetByIdAsync(int id)
        {
            return await _context.Memberships.FindAsync(id); 
        }

        public async Task<ICollection<Membership>> GetByMemberIdAsync(int memberId) 
        { 
            return await _context.Memberships.AsNoTracking().Where(m => m.MemberId == memberId).ToListAsync(); 
        }
        public async Task<ICollection<Membership>> GetByMembershipPlanIdAsync(int membershipPlanId) 
        { 
            return await _context.Memberships.AsNoTracking().Where(m => m.MembershipPlanId == membershipPlanId).ToListAsync(); 
        }

        public async Task UpdateAsync(Membership membership) 
        {
            _context.Memberships.Update(membership);
        }

        public async Task<PagedResult<Membership>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Memberships.Include(m => m.Member)
                                            .Include(m => m.MembershipPlan)
                                            .AsNoTracking();

            if (!string.IsNullOrEmpty(paginationParams.Search))
            {
                var searchTerm = paginationParams.Search.Trim();

                if (DateTime.TryParse(searchTerm, out DateTime searchDate))
                {
                    query = query.Where(m => m.StartDate.Date == searchDate.Date ||
                                     m.EndDate.Date == searchDate.Date);
                }
                else
                {
                    query = query.Where(m => m.Member.FirstName.ToLower().Contains(searchTerm) ||
                                         m.Member.LastName.ToLower().Contains(searchTerm) ||
                                         m.Member.DocumentNumber.Contains(searchTerm) ||
                                         m.MembershipPlan.Name.ToLower().Contains(searchTerm));
                }
            }

            var sortBy = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sortBy switch
            {
                "StartDate" => paginationParams.Descending ? query.OrderByDescending(m => m.StartDate) : query.OrderBy(m => m.StartDate),
                "EndDate" => paginationParams.Descending ? query.OrderByDescending(m => m.EndDate) : query.OrderBy(m => m.EndDate),
                "Status" => paginationParams.Descending ? query.OrderByDescending(m => m.Status) : query.OrderBy(m => m.Status),
                _ => paginationParams.Descending ? query.OrderByDescending(m => m.Id) : query.OrderBy(m => m.Id)
            };

            var totalCount = await query.CountAsync();

            var memberships = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<Membership>
            {
                Items = memberships,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }
    }
}
