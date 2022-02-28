using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepositoryWrapper
    {
        IContentRepository Content { get; }
        IAccountRepository Account { get; }
        Task SaveAsync();
    }
}
