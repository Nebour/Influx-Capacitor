using System;

namespace Tharga.Influx_Capacitor.Entities
{
    public class PingStatus
    {
        private readonly string _errorMessage;
        private readonly bool _success;
        private readonly TimeSpan _responseTime;
        private readonly string _version;

        public PingStatus(string errorMessage)
        {
            _errorMessage = errorMessage;
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

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }
    }
}