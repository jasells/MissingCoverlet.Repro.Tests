using System;
using NetMQ;
using NetMQ.Sockets;
using Debug = System.Diagnostics.Debug;

namespace MissingCoverlet.Repro
{
    public class Subscriber
    {

        public int? TestProperty { get; set; } = null;

        public Subscriber()
        {
            _sub = new SubscriberSocket();

            _sub.ReceiveReady += Sub_ReceiveReady;
        }

        public Subscriber Start(System.Net.IPEndPoint remote) => Start($"{remote.Address}:{remote.Port}");


        public Subscriber Start(string remoteEndPoint)
        {
            _sub.Connect("tcp://" + remoteEndPoint);

            Debug.WriteLine($"in {nameof(Subscriber)}.{nameof(Start)} Zmq is Connected****************");

            _poller = _poller ?? new NetMQPoller();

            if (!_poller.IsRunning) { _poller.RunAsync(); }

            _poller.Add(_sub);

            return this;
        }

        public void MethodForTesting(int? value)
        {
            if (value.HasValue)
            {
                TestProperty = value;
            }
            else
            {
                ++TestProperty;
            }
        }

        private void Sub_ReceiveReady(object sender, NetMQSocketEventArgs e)
        {
            Debug.WriteLine($"in {nameof(Subscriber)}.{nameof(Sub_ReceiveReady)}:  hasData = {e.IsReadyToReceive}****************");
        }

        private static NetMQPoller _poller = null;
        
        private SubscriberSocket _sub;
    }
}
