using System;

namespace Tharga.Influx_Capacitor.Entities
{
    public class PingStatus
    {
        private readonly Exception _exception;
        private readonly bool _success;
        private readonly TimeSpan _responseTime;
        private readonly string _version;

        public PingStatus(Exception exception)
        {
            _exception = exception;
            _success = false;
        }

        public PingStatus(bool success, TimeSpan responseTime, string version)
        {
            _success = success;
            _responseTime = responseTime;
            _version = version;
        }

        public bool Success
        {
            get { return _success; }
        }

        public TimeSpan ResponseTime
        {
            get { return _responseTime; }
        }

        public string Version
        {
            get { return _version; }
        }

        public Exception Exception
        {
            get { return _exception; }
        }
    }
}