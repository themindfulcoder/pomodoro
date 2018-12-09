
using System.Collections.Generic;

namespace pomo_api.Repositories
{
    public interface TasksRepository
    {
        IEnumerable<Models.Task> Get();
        Models.Task Get(int id);
    }
}