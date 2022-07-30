﻿using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisServer
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private IDatabase _database;
        private string configurationString;
        private int _currentDatabaseId = 0;
        public RedisServer(IConfiguration configuration)
        {
            createRedisConfigurationString(configuration);

            _connectionMultiplexer = ConnectionMultiplexer.Connect(configurationString);
            _database = _connectionMultiplexer.GetDatabase(_currentDatabaseId);
        }

        public IDatabase Database => _database;
        public IEnumerable<RedisKey> Keys(string pattern)
            => _connectionMultiplexer.GetServer(configurationString).Keys(_currentDatabaseId, pattern);

        public void FlushDatabase()
        {
            _connectionMultiplexer.GetServer(configurationString).FlushDatabase(_currentDatabaseId);
        }

        private void createRedisConfigurationString(IConfiguration configuration)
        {
            RedisConfiguration redisConfiguration = configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>();
            configurationString = String.Format($"{redisConfiguration.Host}:{redisConfiguration.Port}");
        }
    }
}
