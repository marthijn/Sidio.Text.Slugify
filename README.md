# Sidio.Text.Slugify
Sidio.Text.Slugify is a simple NuGet package that converts a string to an URL-friendly string, 
also called a _slug_.

# Installation
Add the NuGet package to your project.

_This package is not yet available on NuGet._

# Usage

## Dependency injection
```csharp
services.AddSlugifier();
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
