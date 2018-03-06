using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ConnelHooley.TestHelpers.Abstractions;

namespace ConnelHooley.TestHelpers
{
    internal static class TestHelperConfiguratorInstantiator
    {
        static TestHelperConfiguratorInstantiator()
        {
            var currentDllUri = Assembly.GetExecutingAssembly().CodeBase;
            var currentFolderUri = Path.GetDirectoryName(currentDllUri) ?? throw new Exception("Executing assembly's code base is not a valid file path");
            var currentDir = new Uri(currentFolderUri).LocalPath;
            foreach (var dllFile in Directory.GetFiles(currentDir, "*.TestHelperSupport.dll"))
            {
                Assembly.LoadFrom(dllFile);
            }

            var typeToInstantiate = typeof(ITestHelperConfigurator);

            Configurators = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(a =>
                {
                    try
                    {
                        return a.GetTypes();
                    }
                    catch
                    {
                        return Type.EmptyTypes;
                    }
                }) // Get all types from all assemblies
                .Where(t => typeToInstantiate.IsAssignableFrom(t)) // Filter out types that do not implement ITestHelperConfigurator
                .Where(t => !t.IsInterface) // Filter out types that are interfaces
                .Where(t => !t.IsAbstract) // Filter out types that are abstract classes
                .Where(t => t.GetConstructor(Type.EmptyTypes) != null) // Filter out types that do not have a default constructor
                .Select(t => (ITestHelperConfigurator)Activator.CreateInstance(t)) //Instantiate all implementions of the type
                .ToList();
        }

        public static readonly List<ITestHelperConfigurator> Configurators;
    }
}