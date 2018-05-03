using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DmxSharp.Interfaces;

namespace DmxSharp.Sample
{
    public class AvSink : ISink
    {
        private const int Frequency = 100;
        private const int FrequencyDelta = 10;

        private byte[] _lastChannelValues;

        private readonly IPEndPoint _server;
        private readonly Socket _sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        private readonly Timer _timer;

        public bool TurnedOn { get; private set; }
        public DateTime LastSendout { get; private set; } = DateTime.MinValue;

        public AvSink(string ip, int port)
        {
            _server = new IPEndPoint(IPAddress.Parse(ip), port);
            _timer = new Timer(Timer_Tick);
        }


        public void TurnOn()
        {
            TurnedOn = true;
            _timer.Change(0, Frequency);
        }

        public void TurnOff()
        {
            TurnedOn = false;
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void SetChannels(byte[] data)
        {
            Commit(data);
        }

        protected void Commit(byte[] data)
        {
            if (data.Length != 512) throw new ArgumentException($"{nameof(data)}.Length must be 512.", nameof(data));
            Send(data);
            _lastChannelValues = data;
        }

        private void Timer_Tick(object state)
        {
            Resend();
        }

        private void Resend()
        {
            if ((DateTime.Now - LastSendout).TotalMilliseconds > Frequency - FrequencyDelta)
                Send(_lastChannelValues);
        }

        private void Send(byte[] data)
        {
            if (!TurnedOn) return;
            _sock.SendTo(data, _server);
            LastSendout = DateTime.Now;
        }
    }
}