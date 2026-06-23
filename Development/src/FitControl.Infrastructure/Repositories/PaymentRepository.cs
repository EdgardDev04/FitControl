using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Domain.Enums;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly FitControlDbContext _context;

        public PaymentRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<bool> AnyPendingByMemberIdAsync(int memberId) 
        {
            return await _context.Payments.AsNoTracking().AnyAsync(p => p.MemberId == memberId && p.Status == PaymentStatus.Pending);
        }

        public async Task DeleteAsync(Payment payment)
        {
            _context.Payments.Remove(payment);
        }

        public async Task<ICollection<Payment>> GetAllAsync() 
        {
            return await _context.Payments.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Payment>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Payments.AsNoTracking().Where(p => p.PaidAt >= startDate && p.PaidAt <= endDate).ToListAsync();
        }

        public async Task<ICollection<Payment>> GetAllByMethodAsync(PaymentMethod method)
        {
            return await _context.Payments.AsNoTracking().Where(p => p.Method == method).ToListAsync();
        }

        public async Task<ICollection<Payment>> GetAllByRangeAmountAsync(decimal minAmount, decimal maxAmount) 
        {
            return await _context.Payments.AsNoTracking().Where(p => p.Amount >= minAmount && p.Amount <= maxAmount).ToListAsync();
        }        
        
        public async Task<ICollection<Payment>> GetAllByStatusAsync(PaymentStatus status)
        {
            return await _context.Payments.AsNoTracking().Where(p => p.Status == status).ToListAsync();
        }

        public async Task<ICollection<Payment>> GetAllByUserIdAsync(int memberId)
        {
            return await _context.Payments.AsNoTracking().Where(p => p.MemberId == memberId).ToListAsync();
        }

        public async Task<Payment?> GetByAmountAsync(decimal amount) 
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Amount == amount);
        }

        public async Task<Payment?> GetByDateAsync(DateTime date)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.PaidAt == date);
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }
        
        public async Task<Payment?> GetbyMemberIdAsync(int memberId)
        {
           return await _context.Payments.FirstOrDefaultAsync(p => p.MemberId == memberId);
        }

        public async Task<PagedResult<Payment>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Payments.AsNoTracking();

            if (!string.IsNullOrEmpty(paginationParams.Search))
            {
                if (DateTime.TryParse(paginationParams.Search, out DateTime searchDate))
                {
                    query = query.Where(p => p.PaidAt.Date == searchDate.Date);
                }
                else
                {
                    query = query.Where(p => p.Amount.ToString().Contains(paginationParams.Search) ||
                                             p.Method.ToString().Contains(paginationParams.Search) ||
                                             p.Status.ToString().Contains(paginationParams.Search)
                    ); 
                }
            }

            var sortBy = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sortBy switch
            {
                "Amount" => paginationParams.Descending ? query.OrderByDescending(p => p.Amount) : query.OrderBy(p => p.Amount),
                "Method" => paginationParams.Descending ? query.OrderByDescending(p => p.Method) : query.OrderBy(p => p.Method),
                "Status" => paginationParams.Descending ? query.OrderByDescending(p => p.Status) : query.OrderBy(p => p.Status),
                _ =>paginationParams.Descending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id),
            };

            var totalCount = await query.CountAsync();

            var payments = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<Payment>
            {
                Items = payments,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
        }
    }
}
 