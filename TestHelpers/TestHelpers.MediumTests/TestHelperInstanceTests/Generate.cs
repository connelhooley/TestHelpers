using System;
using ConnelHooley.TestHelpers.MediumTests.Example;
using FluentAssertions;
using Xunit;

namespace ConnelHooley.TestHelpers.MediumTests.TestHelperInstanceTests
{
    public class Generate
    {
        [Fact]
        public void TestHelperInstance_GenerateTypesFromConfiguratorsInTestHelperSupportAssemblies()
        {
            var sut = new TestHelperInstance(context => { });

            var result1 = sut.Generate<ExamplePoco1>();
            result1.WebSite.Should().Be(new Uri("http://example.com"));

            var result2 = sut.Generate<ExamplePoco2>();
            result2.Id.Should().Be(5);
        }

        [Fact]
        public void TestHelperInstance_GenerateTypesFromConfiguratorsInExecutingAssembly()
        {
            var sut = new TestHelperInstance(context => { });

            var result = sut.Generate<DateTime>();

            result.Should().Be(DateTime.MaxValue);
        }

        [Fact]
        public void TestHelperInstance_GenerateTypesInstanceConfig()
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