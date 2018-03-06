using System;
using System.Net;
using System.Net.Mail;
using Wincubate.WorkshopA.Utility.Logging;

namespace Wincubate.WorkshopA.Business
{
    public class EmailTransmissionStrategy : ITransmissionStrategy, IDisposable
    {
        private readonly ILoggerFactory _loggerFactory;
        private SmtpClient _smtpClient;
        private readonly MailAddress _from;

        #region IDisposable Members

        private bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose( bool disposing )
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    _smtpClient?.Dispose();
                }
            }
            _isDisposed = true;
        }

        #endregion

        public EmailTransmissionStrategy( ILoggerFactory loggerFactory )
        {
            _loggerFactory = loggerFactory;

            string host = "smtp.gmail.com";
            _smtpClient = new SmtpClient
            {
                Host = host,
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("wincubate.test.user@gmail.com", "ea?lrzrplxp?c?em")
            };

            _from = new MailAddress("wincubate.test.user@gmail.com", "Wincubate Test User");
        }

        public void Transmit( IUser recipient, SingleMessageInstance instance )
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(EmailTransmissionStrategy));
            }

            try
            {
                MailAddress to = new MailAddress(recipient.Email, recipient.Name);
                MailMessage emailMessage = new MailMessage(_from, to)
                {
                    Subject = "Design Patterns in C# message",
                    Body = instance.Contents
                };
                _smtpClient.Send(emailMessage);
            }
            catch( Exception exception )
            {
                throw new MessagingException(
                    $"Could not transmit STMP email message {instance.InstanceId} to {recipient.Email}",
                    exception,
                    MessagingExceptionReason.MessageSendError
                );
            }

            ILogger logger = _loggerFactory.Create(nameof(EmailTransmissionStrategy));
            logger.Info("Successfully sent STMP email message", recipient.Email, instance.InstanceId);
        }
    }
}