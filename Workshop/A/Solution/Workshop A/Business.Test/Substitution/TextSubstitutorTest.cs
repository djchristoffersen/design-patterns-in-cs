using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Wincubate.WorkshopA.Data;

namespace Wincubate.WorkshopA.Business.Test
{
    [TestClass]
    public class TextSubstitutorTest
    {
        [TestMethod]
        public void TestSubstitutionOk()
        {
            MessageTemplate template = new MessageTemplate
            {
                Id = 1,
                Culture = "en",
                Text = "Hello, {0}. The time is now {1}"
            };

            TextSubstitutor substitutor = new TextSubstitutor();

            DateTime now = DateTime.Now;
            IEnumerable<object> parameters = new List<object>
            {
                "World",
                now
            };

            string actual = substitutor.Substitute(template, parameters);
            string expected = $"Hello, World. The time is now {now}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException( typeof( MessagingException ))]
        public void TestSubstitutionMissingParameter()
        {
            MessageTemplate template = new MessageTemplate
            {
                Id = 1,
                Culture = "en",
                Text = "Hello, {0}. The time is now {1}, but not {2}"
            };

            TextSubstitutor substitutor = new TextSubstitutor();

            DateTime now = DateTime.Now;
            IEnumerable<object> parameters = new List<object>
            {
                "World",
                now
            };

            string actual = substitutor.Substitute(template, parameters);
        }
    }
}
