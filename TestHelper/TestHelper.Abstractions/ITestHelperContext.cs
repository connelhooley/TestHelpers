using System;

namespace ConnelHooley.TestHelper.Abstractions
{
    public interface ITestHelperContext
    {
        void Register<T>(Func<T> creator);
        T Generate<T>();
    }
}