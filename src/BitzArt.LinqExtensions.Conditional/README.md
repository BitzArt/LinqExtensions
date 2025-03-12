[![NuGet version](https://img.shields.io/nuget/v/BitzArt.LinqExtensions.Conditional.svg)](https://www.nuget.org/packages/BitzArt.LinqExtensions.Conditional/)
[![NuGet downloads](https://img.shields.io/nuget/dt/BitzArt.LinqExtensions.Conditional.svg)](https://www.nuget.org/packages/BitzArt.LinqExtensions.Conditional/)

# Overview

`BitzArt.LinqExtensions.Conditional` is a NuGet package that allows building complex conditional expressions using LINQ.

## How it Works

### 1. Install

You can install the package via NuGet using the following command:

```bash
dotnet add package BitzArt.LinqExtensions.Conditional
```

### 2. Use

#### 2.1. Conditional 'Where' builder

'Where' condition builder allows building more complex conditional expressions. First, define the selector for a property you are planning on working with:

```csharp
public class TestClass
{
    public int SomeProperty { get; set;}
}

public void Example()
{
    // Create 10 objects of TestClass type
    var data = Enumerable.Range(1, 10).Select(x => new TestClass { SomeProperty = x });

    var queryable = data.AsQueryable();

    // Define property selector
    var whereQuery = queryable.Where(x => x.SomeProperty);
}
```

Now you can apply one or multiple conditions to the selected property:

```csharp
public void Example()
{
    // Create 10 objects of TestClass type
    var data = Enumerable.Range(1, 10).Select(x => new TestClass { SomeProperty = x });

    var queryable = data.AsQueryable();

    // Define property selector
    var result = queryable
        .Where(x => x.SomeProperty)
            .IsTrue(x => x % 2 == 0); // Select only even numbers
            .IsTrue(x => x > 5); // Select only numbers greater than 5
}
```

The resulting query is equivalent to the following LINQ query:

```csharp
var result = queryable.Where(x => x.SomeProperty % 2 == 0 && x.SomeProperty > 5);
```

Decoupling of the property selector from the conditional filtration expression is an additional benefit that might simplify building some complex queries.