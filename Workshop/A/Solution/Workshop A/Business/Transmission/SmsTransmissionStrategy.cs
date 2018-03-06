using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Wincubate.WorkshopA.Utility.Logging;

namespace Wincubate.WorkshopA.Business
{
    public class SmsTransmissionStrategy : ITransmissionStrategy
    {
        private readonly static string _accountSid = "ACa5?64844f11c4152c5e4db4bc202c7??";
        private readonly static string _authToken = "b978????5570945b775bac117f5b7059";

        private readonly ILoggerFactory _loggerFactory;
        private readonly PhoneNumber _from;

        public SmsTransmissionStrategy( ILoggerFactory loggerFactory )
        {
            _loggerFactory = loggerFactory;

            _from = new PhoneNumber("+46769439439");
        }

        public void Transmit( IUser recipient, SingleMessageInstance instance )
        {
            if( string.IsNullOrWhiteSpace( recipient.Phone ) )
            {
                throw new MessagingException(
                    $"No phone number specified for {recipient.Name} in message instance {instance.InstanceId}",
                    reason: MessagingExceptionReason.MessageSendError
                );
            }

            TwilioClient.Init(_accountSid, _authToken);

            PhoneNumber to = new PhoneNumber(recipient.Phone);
            MessageResource mr = MessageResource.Create(to,
                from: _from,
                body: instance.Contents);

            if( mr.ErrorCode.HasValue )
            {
                throw new MessagingException(
                    $"SMS to {recipient.Phone} was not delivered by Twilio. Error code {mr.ErrorCode.Value} in message instance {instance.InstanceId}",
                    reason: MessagingExceptionReason.MessageSendError
                );
            }

            ILogger logger = _loggerFactory.Create(nameof(SmsTransmissionStrategy));
            logger.Info("Successfully sent SMS text message", recipient.Phone, instance.InstanceId);
        }
    }
}