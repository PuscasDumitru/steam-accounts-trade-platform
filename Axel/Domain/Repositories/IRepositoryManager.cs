
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IAnnouncementRepository AnnouncementRepository { get; }
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
