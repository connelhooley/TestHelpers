using System;
using Akka.Actor;
using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.Akka.TestHelperSupport
{
    public class AkkaTestHelperConfigurator : ITestHelperConfigurator
    {
        public void Configure(ITestHelperContext x)
        {
            x.Register(() => ActorPath.Parse($"akka://user/{Guid.NewGuid()}"));
        }
    }
}