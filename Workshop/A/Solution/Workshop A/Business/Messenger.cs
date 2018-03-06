using System;
using Wincubate.WorkshopA.Data;
using Wincubate.WorkshopA.Utility.Data;
using Wincubate.WorkshopA.Utility.Logging;

namespace Wincubate.WorkshopA.Business
{
    public class Messenger
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IRepository<MessageTemplate> _repository;
        private readonly ITransmissionStrategy _strategy;
        private readonly TextSubstitutor _substitutor;

        public Messenger(
            ILoggerFactory loggerFactory,
            IRepository<MessageTemplate> repository,
            ITransmissionStrategy strategy )
        {
            _loggerFactory = loggerFactory;
            _repository = repository;
            _strategy = strategy;

            _substitutor = new TextSubstitutor();
        }

        public void Send( IMessage message )
        {
            ILogger logger = _loggerFactory.Create(nameof(Messenger));

            // Step 3a)
            MessageTemplate messageTemplate = _repository.GetById(message.MessageTemplateId);

            // Step 3b)
            string contents = _substitutor.Substitute(messageTemplate, message.Parameters);
            SingleMessageInstance instance = new SingleMessageInstance(contents);

            // Step 3c)
            _strategy.Transmit(message.Recipient, instance);

            logger.Info("Message Send() completed successfully", message );
        }
    }
}