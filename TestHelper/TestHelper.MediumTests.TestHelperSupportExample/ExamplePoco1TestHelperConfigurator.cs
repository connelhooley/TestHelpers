using System;
using ConnelHooley.TestHelper.Abstractions;
using ConnelHooley.TestHelper.MediumTests.CustomTypes;

namespace ConnelHooley.TestHelper.MediumTests.TestHelperSupportExample
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