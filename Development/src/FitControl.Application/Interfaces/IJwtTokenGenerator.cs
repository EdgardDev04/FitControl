using FitControl.Domain.ValueObject;

namespace FitControl.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken( int userId, Email email, IEnumerable<string>? roles = null);
    }
}
