using System.Collections.Generic;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace pomo_api.Repositories
{
    public class TaskRepositoryImplementation : TasksRepository
    {
        private IRedisTypedClient<Models.Task> redisClient { get; set; }
        public TaskRepositoryImplementation(IRedisClient redisClient)
        {
            this.redisClient = redisClient.As<Models.Task>();
        }
        public IEnumerable<Models.Task> Get()
        {
            return redisClient.GetAll();
        }
        
        public Models.Task Get(int id)
        {
            return redisClient.GetById(id);
        }

        public Models.Task Store(Models.Task task)
        {
            return redisClient.Store(task);
        }
    }
}