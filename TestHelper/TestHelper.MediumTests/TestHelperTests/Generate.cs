using System;
using ConnelHooley.TestHelper.MediumTests.CustomTypes;
using FluentAssertions;
using Xunit;

namespace ConnelHooley.TestHelper.MediumTests.TestHelperTests
{
    public class Generate
    {
        [Fact]
        public void TestHelper_GenerateTypesFromConfigurators()
        {
            var result1 = TestHelper.Generate<ExamplePoco1>();
            result1.WebSite.Should().Be(new Uri("http://example.com"));

            var result2 = TestHelper.Generate<ExamplePoco2>();
            result2.Id.Should().Be(5);
        }
    }
}