using ConnelHooley.TestHelper.Abstractions;
using ConnelHooley.TestHelper.MediumTests.CustomTypes;

namespace ConnelHooley.TestHelper.MediumTests.TestHelperSupportExample
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