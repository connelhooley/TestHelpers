using System;
using ConnelHooley.TestHelper.MediumTests.CustomTypes;
using FluentAssertions;
using Xunit;

namespace ConnelHooley.TestHelper.MediumTests.TestHelperInstanceTests
{
    public class Generate
    {
        [Fact]
        public void TestHelper_GenerateTypesFromConfigurators()
        {
            var sut = new TestHelperInstance(context => { });

            var result1 = sut.Generate<ExamplePoco1>();
            result1.WebSite.Should().Be(new Uri("http://example.com"));

            var result2 = sut.Generate<ExamplePoco2>();
            result2.Id.Should().Be(5);
        }

        [Fact]
        public void TestHelper_GenerateTypesInstanceConfig()
        {
            var sut = new TestHelperInstance(context =>
            {
                context.Register(() => new ExamplePoco1
                {
                    Name = context.Generate<string>(),
                    WebSite = new Uri("http://example2.co.uk")
                });
            });

            var result = sut.Generate<ExamplePoco1>();
            result.WebSite.Should().Be(new Uri("http://example2.co.uk"));
        }
    }
}