using FitControl.Domain.Common;
using FitControl.Domain.Entities;

namespace FitControl.Domain.Interfaces
{
    public interface IClassTypeRepository : IGenericRepository<ClassType>
    {
       Task GetByNameAsync(string name);
    }
}
