using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.TestHelpers.MediumTests.Example.TestHelperSupport
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