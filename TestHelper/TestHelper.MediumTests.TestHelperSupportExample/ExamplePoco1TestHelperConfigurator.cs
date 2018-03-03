using System;
using ConnelHooley.TestHelpers.Abstractions;
using ConnelHooley.TestHelpers.MediumTests.CustomTypes;

namespace ConnelHooley.TestHelpers.MediumTests.TestHelperSupportExample
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