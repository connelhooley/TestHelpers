using System.Linq;
using ConnelHooley.TestHelpers.MediumTests.Example.TestHelperSupport;
using FluentAssertions;
using Xunit;

namespace ConnelHooley.TestHelpers.MediumTests.TestHelperConfiguratorInstantiatorTests
{
    public class Configurators
    {
        [Fact]
        public void TestHelperConfiguratorInstantiator_InstantiatesAllConfigurators()
        {
            var result = TestHelperConfiguratorInstantiator.Configurators;

            result
                .Select(configurator => configurator.GetType())
                .Should()
                .BeEquivalentTo(typeof(ExecutingAssemblyTestHelperConfigurator), typeof(ExamplePoco1TestHelperConfigurator), typeof(ExamplePoco2TestHelperConfigurator));
        }
    }
}