using ConnelHooley.TestHelpers.Abstractions;
using ConnelHooley.TestHelpers.MediumTests.CustomTypes;

namespace ConnelHooley.TestHelpers.MediumTests.TestHelperSupportExample
{
    public class ExamplePoco2TestHelperConfigurator : ITestHelperConfigurator
    {
        public void Configure(ITestHelperContext config)
        {
            config.Register(() => new ExamplePoco2
            {
                Name = config.Generate<string>(),
                Id = 5
            });
        }
    }
}