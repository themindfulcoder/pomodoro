using System;
using ServiceStack.Redis;

namespace redis_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new RedisManagerPool("localhost:6379");
            using (var client = manager.GetClient())
            {
                client.Set("foo", "bar");
                Console.WriteLine("foo={0}", client.Get<string>("foo"));
            }
        }
    }
}
