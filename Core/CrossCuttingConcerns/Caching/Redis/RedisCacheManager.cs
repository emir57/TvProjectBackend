using Core.Utilities.Results;
using Newtonsoft.Json;
using ServiceStack.Redis;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly RedisServer _redisServer;
        public RedisCacheManager(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }
        public void Add(string key, object value, int duration)
        {
            //dynamic result = value;
            //if (value is Task)
            //{
            //    var dynamicValue = value as dynamic;
            //    result = dynamicValue.Result;
            //}
            //var jsonData = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            //_redisServer.Database.StringSet(key, jsonData, TimeSpan.FromMinutes(duration));
            RedisInvoker(x => x.Add(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }), TimeSpan.FromMinutes(duration)));
        }

        public T Get<T>(string key)
        {
            //var redisData = _redisServer.Database.StringGet(key);
            //return JsonConvert.DeserializeObject<T>(redisData);
            var result = default(T);
            RedisInvoker(x => { result = x.Get<T>(key); });
            return result;
        }

        public object Get(string key)
        {
            var redisData = _redisServer.Database.StringGet(key);
            return JsonConvert.DeserializeObject(redisData);
        }

        public bool IsAdd(string key)
        {
            return _redisServer.Database.KeyExists(key);
        }

        public void Remove(string key)
        {
            _redisServer.Database.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var keys = _redisServer.Keys(pattern).ToArray();
            _redisServer.Database.KeyDelete(keys);
        }
        private void RedisInvoker(Action<RedisClient> redisAction)
        {
            using (var client = new RedisClient("localhost", 49153, "redispw"))
            {
                redisAction.Invoke(client);
            }
        }
    }
}
