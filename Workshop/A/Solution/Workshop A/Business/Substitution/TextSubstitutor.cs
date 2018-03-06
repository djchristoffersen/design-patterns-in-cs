using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.WorkshopA.Data;

namespace Wincubate.WorkshopA.Business
{
    public class TextSubstitutor
    {
        public string Substitute(
            MessageTemplate messageTemplate, 
            IEnumerable<object> parameters )
        {
            string messageContents = string.Empty;
            try
            {
                messageContents = string.Format(
                    messageTemplate.Text,
                    parameters?.ToArray() ?? new object[0]);
            }
            catch (FormatException exception)
            {
                throw new MessagingException(
                    $"Could not substitute the parameters into the message template contents " +
                    $"\"{messageTemplate.Text}\" [Id:{messageTemplate.Id}]",
                    exception,
                    MessagingExceptionReason.TextSubstitutionError
                );
            }

            return messageContents;
        }
    }
}
