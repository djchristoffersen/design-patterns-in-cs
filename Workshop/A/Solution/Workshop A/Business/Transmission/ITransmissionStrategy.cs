using System;

namespace Wincubate.WorkshopA.Business
{
    public interface ITransmissionStrategy
    {
        void Transmit( IUser recipient, SingleMessageInstance instance );
    }
}
