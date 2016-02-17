namespace Tharga.Influx_Capacitor.Entities
{
    public class QueueStatus
    {
        private readonly PingStatus _pingStatus;
        private readonly ConnectionSettings _connecion;
        private readonly int _queueCount;

        public QueueStatus(PingStatus pingStatus, ConnectionSettings connecion, int queueCount)
        {
            _pingStatus = pingStatus;
            _connecion = connecion;
            _queueCount = queueCount;
        }

        public PingStatus Status
        {
            get { return _pingStatus; }
        }

        public ConnectionSettings Connecion
        {
            get { return _connecion; }
        }

        public int QueueCount
        {
            get { return _queueCount; }
        }
    }
}