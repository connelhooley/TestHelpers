using System;
using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.TestHelpers.MediumTests.Example.TestHelperSupport
{
    public class ExamplePoco1TestHelperConfigurator : ITestHelperConfigurator
    {
        public void Configure(ITestHelperContext config)
        {
            config.Register(() => new ExamplePoco1
            {
                Name = config.Generate<string>(),
                WebSite = new Uri("http://example.com")
            });
        }
    }
}