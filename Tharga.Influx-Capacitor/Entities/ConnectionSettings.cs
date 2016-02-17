namespace Tharga.Influx_Capacitor.Entities
{
    public class ConnectionSettings
    {
        private readonly bool _enabled;
        private readonly string _address;
        private readonly string _databaseName;
        private readonly string _userName;

        public ConnectionSettings(bool enabled, string address, string databaseName, string userName)
        {
            _enabled = enabled;
            _address = address;
            _databaseName = databaseName;
            _userName = userName;
        }

        public bool Enabled
        {
            get { return _enabled; }
        }

        public string Address
        {
            get { return _address; }
        }

        public string DatabaseName
        {
            get { return _databaseName; }
        }

        public string UserName
        {
            get { return _userName; }
        }
    }
}