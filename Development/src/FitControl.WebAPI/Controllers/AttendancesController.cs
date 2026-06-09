using FitControl.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await _attendanceService.GetAllAttendancesAsync();

            return Ok(attendances);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAttendance([FromRoute] int id)
        {
            var attendance = await _attendanceService.GetAttendanceAsync(id);

            return Ok(attendance);
        }

        [HttpGet("Member/{memberId:int}")]
        public async Task<IActionResult> GetAttendancesByMemberId( [FromRoute] int memberId)
        {
            var attendance = await _attendanceService.GetAttendanceByMemberIdAsync(memberId);

            return Ok(attendance);
        }

        [HttpGet("range-date")]
        public async Task<IActionResult> GetAllAttendancesByDateRange([FromQuery] DateTime startDate,[FromQuery] DateTime endDate)
        {
            var attendances = await _attendanceService.GetAttendanceByDateRangeAsync(startDate, endDate);

            return Ok(attendances);
        }

        [HttpPost("{memberId:int}/checkin")]
        public async Task<IActionResult> RegisterCheckIn([FromRoute] int memberId)
        {
            await _attendanceService.RegisterCheckInAsync(memberId);

            return Ok("Check-in registered successfully.");
        }

        [HttpPost("{memberId:int}/checkout")]
        public async Task<IActionResult> RegisterCheckOut([FromRoute] int memberId)
        {
            await _attendanceService.RegisterCheckOutAsync(memberId);

            return Ok("Check-out registered successfully.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] int id)
        {
            await _attendanceService.DeleteAttendanceAsync(id);

            return NoContent();
        }
    }
}
