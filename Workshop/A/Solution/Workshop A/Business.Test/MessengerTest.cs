using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Wincubate.WorkshopA.Data;
using Wincubate.WorkshopA.Utility.Data;
using Wincubate.WorkshopA.Utility.Logging;

namespace Wincubate.WorkshopA.Business.Test
{
    [TestClass]
    public class MessengerTest
    {
        [TestMethod]
        public void TestMessengerSendOk()
        {
            ILoggerFactory loggerFactory = new NullLoggerFactory();

            IRepository<MessageTemplate> repository =
                new InMemoryRepository<MessageTemplate>(
                    new MessageTemplate { Id = 1, Culture = "da", Text = "Hukommelses-testbesked sendt som {0}!" },
                    new MessageTemplate { Id = 2, Culture = "en", Text = "In-memory test message sent as {0}!" }
                );

            InMemoryTransmissionStrategy inMemory =
                new InMemoryTransmissionStrategy();

            Messenger messenger = new Messenger(loggerFactory, repository, inMemory);

            IUser user = new User
            {
                Name = "Jesper Gulmann Henriksen",
                Email = "jgh@wincubate.net",
                Phone = "+4522123631"
            };

            messenger.Send(new Message
            {
                Recipient = user,
                MessageTemplateId = 1,
                Parameters = new List<object> { "TEST" }
            });


            var (actualUser, actualInstance) = inMemory.Sent.Single();
            Assert.AreEqual(user.Name, actualUser.Name);

            string expectedInstanceContents = "Hukommelses-testbesked sendt som TEST!";
            Assert.AreEqual(expectedInstanceContents, actualInstance.Contents);
        }
    }
}