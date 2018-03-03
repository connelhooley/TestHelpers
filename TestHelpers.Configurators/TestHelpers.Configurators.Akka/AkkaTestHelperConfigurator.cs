﻿using System;
using Akka.Actor;
using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.TestHelpers.Configurators.Akka
{
    public class AkkaTestHelperConfigurator : ITestHelperConfigurator
    {
        public void Configure(ITestHelperContext x)
        {
            x.Register(() => ActorPath.Parse($"akka://user/{Guid.NewGuid()}"));
        }
    }
}