﻿using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable EmptyGeneralCatchClause

namespace ConnelHooley.TestHelpers
{
    internal static class TypeInstantiator
    {
        public static IEnumerable<T> InstantiateAll<T>()
        {
            var typeToInstantiate = typeof(T);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies(); // Get all assemblies
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes()); // Get all types from assemblies
                }
                catch { }
            }
            return types
                .Where(t => typeToInstantiate.IsAssignableFrom(t)) // Filter out types that do not implement the type
                .Where(t => !t.IsInterface) // Filter out types that are interfaces
                .Where(t => !t.IsAbstract) // Filter out types that are abstract classes
                .Where(t => t.GetConstructor(Type.EmptyTypes) != null) // Filter out types that do not have a default constructor
                .Select(t => (T)Activator.CreateInstance(t)); //Instantiate all implementions of the type
        }
    }
}