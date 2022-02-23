using System;
using Xunit;

namespace MissingCoverlet.Repro.Tests2
{
    public class UnitTest1
    {
        [Fact]
        public void CoverageIsCollected()
        {
            var sub = new Subscriber();

            int expected = 1234;

            sub.MethodForTesting(expected);

            Assert.Equal(expected, sub.TestProperty);
        }
    }
}
