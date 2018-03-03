using System;
using ConnelHooley.TestHelpers.MediumTests.CustomTypes;
using FluentAssertions;
using Xunit;

namespace ConnelHooley.TestHelpers.MediumTests.TestHelperTests
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