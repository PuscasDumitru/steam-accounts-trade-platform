
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IContentRepository ContentRepository { get; }
        IAccountRepository AccountRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
