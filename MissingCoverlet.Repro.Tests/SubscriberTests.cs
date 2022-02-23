using System;
using Xunit;

namespace MissingCoverlet.Repro.Tests
{
    public class SubscriberTests
    {
        [Fact]
        public void NoCoverage()
        {
            var sub = new Subscriber()
                          .Start(new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 23456));

            int expected = 1234;

            sub.MethodForTesting(expected);

            Assert.Equal(expected, sub.TestProperty);
        }
    }
}
