# Sidio.Text.Slugify
Sidio.Text.Slugify is a simple NuGet package that converts a string to an URL-friendly string, 
also called a _slug_.

For example, the string `Hello, World!` will be converted to `hello-world`.

# Installation
Add the NuGet package to your project.

_This package is not yet available on NuGet._

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