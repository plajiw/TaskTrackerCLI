using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Domain.Repositories
{
    // TODO: Ler sobre IDispose, Repository Pattern, Dispose Pattern e Command Pattern
    public interface ITaskItemRepository
    {
        void InsertTaskItem (Task item);
    }
}
