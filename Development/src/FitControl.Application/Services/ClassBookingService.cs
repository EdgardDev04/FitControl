using AutoMapper;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Domain.Interfaces;

namespace FitControl.Application.Services
{
    public class ClassBookingService : IClassBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMembershipService _membershipService;

        public ClassBookingService(IUnitOfWork unitOfWork, IMapper mapper, IMembershipService membershipService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _membershipService = membershipService; 
        }

        public async Task BookClassAsync(int memberId, int classSessionId)
        {
            var isActive = await _membershipService.HasActiveMembershipAsync(memberId);

            if (!isActive) 
                throw new InvalidOperationException("Member does not have an active membership.");

            var session = await _unitOfWork.ClassSessions.GetByIdAsync(classSessionId);

            if (session == null)
                throw new InvalidOperationException("Class session not found.");

            if(session.HasStarted())
                throw new InvalidOperationException("Cannot book a class that has already started.");

            if (session.IsFull())
                throw new InvalidOperationException("Class session is full.");

            var isAlreadyBooked = await _unitOfWork.ClassBookings.ExistBookingAsync(memberId, classSessionId);
            
            if (isAlreadyBooked)
                throw new InvalidOperationException("Member has already booked this class.");

            var booking = new ClassBooking(memberId, classSessionId);

            await _unitOfWork.ClassBookings.AddAsync(booking);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CancelBookingAsync(int bookingId)
        {
            var booking = await _unitOfWork.ClassBookings.GetByIdAsync(bookingId);

            if (booking == null)
                throw new InvalidOperationException("Booking not found.");
            
            if (booking.Status != BookingStatus.Reserved)
                throw new InvalidOperationException("Only reserved bookings can be cancelled.");

            if (booking.Session.HasStarted())
                throw new InvalidOperationException("Cannot cancel a booking for a class that has already started.");


            booking.MarkAsCancelled();

            await _unitOfWork.SaveChangesAsync();
        }

        public Task ConfirmAttendanceAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClassBookingDto>> GetClassSessionBookingsAsync(int classSessionId)
        {
           var bookings = await _unitOfWork.ClassBookings.GetAllByClassSessionIdAsync(classSessionId);

           if (bookings == null)
               return new List<ClassBookingDto>();

           return _mapper.Map<IEnumerable<ClassBookingDto>>(bookings);
        }

        public async Task<IEnumerable<ClassBookingDto>> GetMemberBookingsAsync(int memberId)
        {
            var bookings = await _unitOfWork.ClassBookings.GetAllByMemberIdAsync(memberId);

            if (bookings == null)
                return new List<ClassBookingDto>();

            return _mapper.Map<IEnumerable<ClassBookingDto>>(bookings);
        }

        public async Task<bool> IsClassFullAsync(int classSessionId)
        {
            var session = await _unitOfWork.ClassSessions.GetByIdAsync(classSessionId);

            if (session == null)
                throw new InvalidOperationException();

            if (session.Status == ClassSessionStatus.Cancelled)
                throw new InvalidOperationException("Cannot check availability for a cancelled class.");

            if (session.HasStarted())
                throw new InvalidOperationException("Cannot check availability for a class that has already started.");

            if (session.Status != ClassSessionStatus.Scheduled)
                throw new InvalidOperationException("Can only check availability for scheduled classes.");

            return session.IsFull();
        }
    }
}
