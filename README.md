# Sidio.Text.Slugify
Sidio.Text.Slugify is a simple NuGet package that converts a string to an URL-friendly string, 
also called a _slug_.

For example, the string `Hello, World!` will be converted to `hello-world`.

[![build](https://github.com/marthijn/Sidio.Text.Slugify/actions/workflows/build.yml/badge.svg)](https://github.com/marthijn/Sidio.Text.Slugify/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/Sidio.Text.Slugify)](https://www.nuget.org/packages/Sidio.Text.Slugify/)

# Installation
Add [the NuGet package](https://www.nuget.org/packages/Sidio.Text.Slugify/) to your project.

# Usage

## Dependency injection
```csharp
services.AddSlugifier();
// - or -
services.AddSlugifier(options => {
    options.AddDefaultProcessors = false;
    options.Processors.Add(new LowerCaseProcessor());
}); 
```

```csharp
public class MyClass()
{
    public MyClass(ISlugifier slugifier)
    {
        var slug = slugifier.Slugify("Hello, World!");
    }
}
```

## Direct usage
```csharp
var slugifier = Slugifier.Create();
var slug = slugifier.Slugify("Hello, World!");
```

## Extensions
Using the extension method is not recommended because it creates a new instance of 
the `Slugifier` class every time it is called.
```csharp
using Sidio.Text.Slugify.Extensions;

var slug = "Hello, World!".Slugify();
```

# Extensibility
You can implement your own processors by implementing the `SlugifyProcessor` class. For example:
```csharp
public sealed class RemoveExclamationMarkProcessor : SlugifyProcessor
{
    protected override string ProcessInput(string input)
    {
        return input.Replace("!", string.Empty);
    }

    // run this processor first
    public override int Order => 0; // or int.MaxValue for last
}
```