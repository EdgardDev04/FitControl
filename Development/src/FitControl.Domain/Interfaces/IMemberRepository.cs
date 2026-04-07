using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task GetByDocumentAsync (string document);
        Task GetByStatusAsync (bool status);

    }
}
