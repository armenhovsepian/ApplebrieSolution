using Applebrie.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applebrie.Core.Interfaces
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypeDto>> GetAllAsync();
    }
}
