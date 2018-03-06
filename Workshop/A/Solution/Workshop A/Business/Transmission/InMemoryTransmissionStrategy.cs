using System.Collections.Generic;

namespace Wincubate.WorkshopA.Business
{
    public class InMemoryTransmissionStrategy : ITransmissionStrategy
    {
        public IEnumerable<(IUser recipient, SingleMessageInstance instance)> Sent => _sent;
        private readonly IList<(IUser recipient, SingleMessageInstance instance)> _sent;

        public InMemoryTransmissionStrategy()
        {
            _sent = new List<(IUser recipient, SingleMessageInstance instance)>();
        }

        public void Transmit( IUser recipient, SingleMessageInstance instance )
        {
            _sent.Add((recipient, instance));
        }
    }
}
