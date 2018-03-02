# TestHelper
A class to randomly generate values. Useful for unit tests.

# Methods

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
Returns a random item from an IEnumerable.

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
Removes a random item from a List and returns the removed item.

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
Randomly cases a string so some of its letters and uppercase, and some are lower case.

``` csharp
var randomMixedCase = TestHelper.RandomCaseString("hello world");
```

It is also exposed as an extension method.

``` csharp
var x = "hello world";
var randomMixedCase = x.ToRandomCase();
```

## GenerateString
Returns a random string made up of upper and lower case letters from the alphabet, numbers and some special characters.

``` csharp
var randomString = TestHelper.GenerateString();
```

## GenerateStringFrom
Returns a random string made up of the chars in the given string.

``` csharp
var randomStringMadeUpOfAbc = TestHelper.GenerateStringFrom("abc");
```

## GenerateWhitespaceString
Returns a string containing 1 to 50 spaces.

``` csharp
var randomWhitespace = TestHelper.GenerateWhitespaceString();
```

## GenerateMany
Runs the creator function between 2 and 100 times and returns the results in an IEnummerable.

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

## Generate
Returns a value created by AutoFixture:

``` csharp
var randomMailAddress = TestHelper.Generate<MailAddress>();
```

To find out how to configure the AutoFixture instance inside the TestHelper please go the Configuration section.

## Configuration
There are two ways of configuring the TestHelper.

## Test Helper Instances
The examples above demonstrate the static `TestHelper` class. It is also possible to create a `TestHelperInstance` class that contains its own configuration.

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
...
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
}
```

This is useful for when a particular group of tests need a particular configuration.

## Configurators
Sometimes you always want to create a specified type the same way throughout a test project. Both the static `TestHelper` class and the `TestHelperInstance` class use reflection to look for implementations an interface called `ITestHelperConfigurator`. These are then run to configure the test helpers.

For example:

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
...
public class TestHelperConfigurator : ITestHelperConfigurator
{
    public void Configure(ITestHelperContext x)
    {
        x.Register(() => "hello");
        x.Register(() => 5);
    }
}
```

The `TestHelperInstance` loads in any `ITestHelperConfigurator` implentations and then loads in its own configuration. This means that if a `TestHelperInstance` registers a type in the action passed into its constructor, this registration will be used instead of any found in any Configurators.

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
...
public class TestHelperConfigurator : ITestHelperConfigurator
{
    public void Configure(ITestHelperContext x)
    {
        x.Register(() => "hello");
    }
}
```