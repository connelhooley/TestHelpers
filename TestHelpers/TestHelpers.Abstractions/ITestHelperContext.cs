using System;

namespace ConnelHooley.TestHelpers.Abstractions
{
    public interface ITestHelperContext
    {
        void Register<T>(Func<T> creator);
        T Generate<T>();
    }
}