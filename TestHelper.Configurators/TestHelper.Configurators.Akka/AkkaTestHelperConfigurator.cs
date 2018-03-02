using System;
using Akka.Actor;
using ConnelHooley.TestHelper.Abstractions;

namespace ConnelHooley.TestHelper.Configurators.Akka
{
    public class AkkaTestHelperConfigurator : ITestHelperConfigurator
    {
        public void Configure(ITestHelperContext x)
        {
            x.Register(() => ActorPath.Parse($"akka://user/{Guid.NewGuid()}"));
        }
    }
}