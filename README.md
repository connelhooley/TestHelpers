# TestHelpers
A class to randomly generate values. Useful for unit tests. Powered by [AutoFixture](https://github.com/AutoFixture/AutoFixture).

> Install-Package ConnelHooley.TestHelpers

# Methods

## Generate
Returns a value created by `AutoFixture`.

``` csharp
var randomMailAddress = TestHelper.Generate<MailAddress>();
```

To find out how to configure the `AutoFixture` instance inside the `TestHelper` please go the [Configuration](#configuration) section.

## GenerateException
Returns an exception with a randomly generated message.

``` csharp
var randomException = TestHelper.GenerateException();
```

## GenerateBool
Returns a random boolean.

``` csharp
var randomBool = TestHelper.GenerateBool();
```

## GenerateDateTime
Returns a random date between 1000 days in the past and 1000 days in the future.

``` csharp
var randomDate = TestHelper.GenerateDateTime();
```

## GenerateDateTimeByWeekDay
Returns a random date between 1000 days in the past and 1007 days in the future on a certain day.

``` csharp
var randomMonday = TestHelper.GenerateDateTimeByWeekDay(DayOfWeek.Monday);
```

## GenerateNumber
Returns a random number. Includes negative values.

``` csharp
var randomNumber = TestHelper.GenerateNumber();
```

## GenerateNumberBelow
Returns a random number below a certain value. Includes negative values.

``` csharp
var randomNumberBelow100 = TestHelper.GenerateNumberBelow(100);
```

## GenerateNumberAbove
Returns a random number above a certain value. Includes negative values.

``` csharp
var randomNumberAbove100 = TestHelper.GenerateNumberAbove(100);
```

## GenerateNumberBetween
Returns a random number between two values. Both the lower and upper bounds are inclusive.

``` csharp
var randomNumberBetween50and100 = TestHelper.GenerateNumberBetween(50, 100);
```

## ChooseRandomItem
Returns a random item from an `IEnumerable`.

``` csharp
var items = new[] {"hello", "world"};
var helloOrWorld = TestHelper.ChooseRandomItem(items);
```

It is also exposed as an extension method.

``` csharp
var items = new[] {"hello", "world"};
var helloOrWorld = items.ChooseRandomItem();
```

## TakeRandomItem
Removes a random item from a `List` and returns the removed item.

``` csharp
var items = new[] {"hello", "world"};
var helloOrWorld = TestHelper.TakeRandomItem(items);
```

It is also exposed as an extension method.

``` csharp
var items = new[] {"hello", "world"};
var helloOrWorld = items.TakeRandomItem();
```

## RandomCaseString
Randomly mix-cases a string so that some of its letters are uppercase and some are lowercase.

``` csharp
var randomMixedCase = TestHelper.RandomCaseString("hello world");
```

It is also exposed as an extension method.

``` csharp
var x = "hello world";
var randomMixedCase = x.ToRandomCase();
```

## GenerateString
Returns a random string made up of letters from the alphabet (uppercase and lowercase), numbers and some special characters.

``` csharp
var randomString = TestHelper.GenerateString();
```

## GenerateStringFrom
Returns a random string made up of the chars in the given string.

``` csharp
var randomStringMadeUpOfNumbers = TestHelper.GenerateStringFrom(TestHelper.Numbers);
```

## GenerateWhitespaceString
Returns a string containing 1 to 50 spaces.

``` csharp
var randomWhitespace = TestHelper.GenerateWhitespaceString();
```

## WrapStringInWhitespace
Returns the given string with 1 to 50 spaces prepended and appended to it.

``` csharp
var helloWorldWrappedInRandomWhitespace = TestHelper.WrapStringInWhitespace("helloworld");
```

It is also exposed as an extension method.

``` csharp
var x = "helloworld";
var helloWorldWrappedInRandomWhitespace = x.WrapStringInWhitespace();
```

## GenerateMany
Runs the creator function between 2 and 100 times and returns the results in an `IEnummerable`.

``` csharp
var randomStrings = TestHelper.GenerateMany(TestHelper.GenerateString);

```

You can also specify how many times to run the creator:

``` csharp
var fiftyRandomStrings = TestHelper.GenerateMany(50, TestHelper.GenerateString);
```

## GenerateEnum
Returns a random enum.

``` csharp
var randomDayOfWeek = TestHelper.GenerateEnum<DayOfWeek>();
```

You can also specify values to exclude:

``` csharp
var randomWeekDay = TestHelper.GenerateEnum(DayOfWeek.Saturday, DayOfWeek.Sunday);
```

## GenerateGuid
Returns a random GUID.

``` csharp
var randomGuid = TestHelper.GenerateGuid();
```

## GetRandomTypeGenerator
Returns a function that in turn returns random types.

``` csharp
var typeGenerator = TestHelper.GetRandomTypeGenerator();
var type1 = typeGenerator();
var type2 = typeGenerator();
```

The method works by getting the assembly of the `Type` type in the System namespace. It then gets all the exported types for that assembly. The returned `Func` randomly selects items from the exported types when it is ran. It removes items from the list as it goes to prevent duplicates. The `Func` will throw when there are no more types to pick from.

## Configuration
There are two ways of configuring the TestHelper.

### Test Helper Instances
So far, we have seen usage of the static `TestHelper` class. It is also possible to create a `TestHelperInstance` class that contains its own configuration.

For example:

``` csharp
public class Program
{
    public static void Main()
    {
        var testHelper = new TestHelperInstance(x =>
        {
            x.Register<User>(() => new User
            {
                Id = TestHelper.GenerateNumber(),
                Username = "ExampleUserName"
            });
        });
        var user = testHelper.Generate<User>();
        Console.WriteLine(user.Username); // Prints "ExampleUserName"
        Console.WriteLine(user.Id); // Prints random ID
        Console.ReadLine();
    }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
}
```

This is useful for when a group of tests needs a particular configuration. The `TestHelperInstance` class has all the same methods as the static `TestHelper` class, although apart from the `Generate<T>()` method, they all just call the static `TestHelper` under the hood.

### Configurators
Sometimes you always want to create a specified type the same way throughout a test project, or even all your test projects. To do this both the static `TestHelper` class and the `TestHelperInstance` scan for an interface called `ITestHelperConfigurator`:

- The test helpers load any DLLs that end with `.TestHelperSupport.dll`.
- They then query all the currently loaded assemblies for implementations of `ITestHelperConfigurator`.
- These Configurators are then run to configure the test helpers.

An example of what using a Configurator would like:

``` csharp
public class Program
{
    public static void Main()
    {
        Console.WriteLine(TestHelper.Generate<string>()); // Prints "hello"
        Console.WriteLine(TestHelper.Generate<int>()); // Prints 5
        Console.ReadLine();
    }
}

public class TestHelperConfigurator : ITestHelperConfigurator
{
    public void Configure(ITestHelperContext x)
    {
        x.Register(() => "hello");
        x.Register(() => 5);
    }
}
```

The `TestHelperInstance` loads in any `ITestHelperConfigurator` implementations and then loads in its own configuration. This means that if a `TestHelperInstance` registers a type in the action passed into its constructor, this registration will be used instead of any found in any Configurators.

For example:

``` csharp
public class Program
{
    public static void Main()
    {
        var testHelper = new TestHelperInstance(x =>
        {
            x.Register(() => "world");
        });
        Console.WriteLine(testHelper.Generate<string>()); // Prints "world"
        Console.ReadLine();
    }
}

public class TestHelperConfigurator : ITestHelperConfigurator
{
    public void Configure(ITestHelperContext x)
    {
        x.Register(() => "hello");
    }
}
```

### Authoring a Configurator
If you create a type that should always be created in a certain way, you can create a NuGet package that references your type and includes an `ITestHelperConfigurator` implementation.

Below is an example type I could publish as a NuGet package called `UpperCaseString`:

``` csharp
public class UpperCaseString
{
    private readonly string _value;

    public UpperCaseString(string x)
    {
        if(x != x.ToUpperInvariant()) throw new ArgumentException("String must be uppercase");
        _value = x;
    }

    public static implicit operator string(UpperCaseString d) => d._value;
}
```

I could then publish the following Configurator as a separate NuGet package called `UpperCaseString.TestHelperSupport`:

``` csharp
public class UpperCaseStringTestHelperConfigurator : ITestHelperConfigurator
{
    public void Configure(ITestHelperContext x)
    {
        x.Register(() => new UpperCaseString(x.Generate<string>().ToUpperInvariant()));
    }
}
```

Calling it `UpperCaseString.TestHelperSupport` ensures that the test helper classes load in the assembly even if no other code references it.

The test helper support package only needs to reference the `ConnelHooley.TestHelpers.Abstractions` package. Then when anyone includes a `UpperCaseString` in their project, they only need to install the support package and the test helper classes will pick up the configurator and successfully create `UpperCaseString` types.
