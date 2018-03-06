using System;
using System.Collections.Generic;
using Wincubate.WorkshopA.Business;
using Wincubate.WorkshopA.Data;
using Wincubate.WorkshopA.Data.EF;
using Wincubate.WorkshopA.Utility.Data;
using Wincubate.WorkshopA.Utility.Data.EF;
using Wincubate.WorkshopA.Utility.Logging;

namespace Wincubate.WorkshopA.ConsoleClient
{    
    class Program
    {
        static void Main( string[] args )
        {
            ILoggerFactory loggerFactory = new ConsoleLoggerFactory();

            using (CachingRepository<MessageTemplate> repository
                = new CachingRepository<MessageTemplate>(
                  new Repository<MessageTemplate>(new MessageTemplatesContext())))
            {
                ITransmissionStrategy transmissionStrategy =
                    new SmsTransmissionStrategy(loggerFactory);

                Messenger messenger = new Messenger(
                    loggerFactory,
                    repository,
                    transmissionStrategy);

                IUser user = new User("Gen-Eric", "jgh@wincubate.net", "+4522123631");

                messenger.Send(new Message
                {
                    Recipient = user,
                    MessageTemplateId = 1,
                    Parameters = new List<object> { "Jesper", DateTime.Now }
                });

                Console.ReadLine();
            }
        }
    }
}
