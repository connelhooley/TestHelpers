using System;
using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.TestHelpers.MediumTests
{
    public class ExecutingAssemblyTestHelperConfigurator : ITestHelperConfigurator
    {
        public void Configure(ITestHelperContext config)
        {
            config.Register(() => DateTime.MaxValue);
        }
    }
}