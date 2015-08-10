using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using InfluxDB.Net;
using InfluxDB.Net.Models;
using Tharga.InfluxCapacitor.Collector.Interface;

namespace Tharga.InfluxCapacitor.Collector.Agents
{
    [ExcludeFromCodeCoverage]
    public class InfluxDbAgent : IInfluxDbAgent
    {
        private readonly InfluxDb _influxDb;
        private readonly IDatabaseConfig _databaseConfig;

        public InfluxDbAgent(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;

            Uri result;
            if (!Uri.TryCreate(_databaseConfig.Url, UriKind.Absolute, out result))
            {
                var exp = new InvalidOperationException("Unable to parse provided connection as url.");
                exp.Data.Add("Url", databaseConfig.Url);
                throw exp;
            }

            _influxDb = new InfluxDb(_databaseConfig.Url, _databaseConfig.Username, _databaseConfig.Password, _databaseConfig.InfluxDbVersion);
        }

        public async Task<InfluxDbApiResponse> WriteAsync(Point[] points)
        {
            return await _influxDb.WriteAsync(_databaseConfig.Name, points);
        }

        public async Task CreateDatabaseAsync(string databaseName)
        {
            await _influxDb.CreateDatabaseAsync(databaseName);
        }

        public async Task<InfluxDbApiResponse> AuthenticateDatabaseUserAsync()
        {
            return await _influxDb.AuthenticateDatabaseUserAsync(_databaseConfig.Name, _databaseConfig.Username, _databaseConfig.Password);
        }

        public async Task<bool> CanConnect()
        {
            var pong = await _influxDb.PingAsync();
            return pong.Success;
        }

        public async Task<Pong> PingAsync()
        {
            return await _influxDb.PingAsync();
        }

        public async Task<string> VersionAsync()
        {
            var pong = await _influxDb.PingAsync();
            return pong.Version;
        }
    }
}