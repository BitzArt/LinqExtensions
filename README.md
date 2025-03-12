[![NuGet version](https://img.shields.io/nuget/v/BitzArt.LinqExtensions.svg)](https://www.nuget.org/packages/BitzArt.LinqExtensions/)
[![NuGet downloads](https://img.shields.io/nuget/dt/BitzArt.LinqExtensions.svg)](https://www.nuget.org/packages/BitzArt.LinqExtensions/)

# Overview

[**BitzArt.LinqExtensions**](https://www.nuget.org/packages/BitzArt.LinqExtensions/) provides additional LINQ extension methods, such as:

- [**.If()**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions/Extensions/IfExtension.cs) - Conditionally applies a transformation to a sequence;
    - Example:
        ```csharp
        public void Example(bool onlyEvenNumbers)
        {
            var numbers = Enumerable.Range(1, 10);

            var result = numbers
                .If(onlyEvenNumbers, q => q
                    .Where(x => x % 2 == 0));
        }
        ```

- [**.WhereIf()**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions/Extensions/WhereIfExtension.cs) - Similar to `.If()`, but applies a condition to a sequence right away;
    - Example:
        ```csharp
        public void Example(bool onlyEvenNumbers)
        {
            var numbers = Enumerable.Range(1, 10);

            var result = numbers.WhereIf(onlyEvenNumbers, x => x % 2 == 0);
        }
        ```

- [**.Median()**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions/Extensions/MedianQueryExtension.cs) - Calculates the median value of a sequence;
    - Example:
        ```csharp
        public void Example()
        {
            var numbers = Enumerable.Range(1, 10);

            var median = numbers.Median(x => x);
        }
        ```

- [**.OrderBy()**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions/Extensions/OrderExtensions.cs) - Additional ordering extensions.
    - Comes with an `OrderDirection` enum, allowing usage like:
        ```csharp
        public void Example(OrderDirection direction)
        {
            var numbers = Enumerable.Range(1, 10);

            // will order either ascending or descending, depending on the `direction` parameter
            var result = numbers.OrderBy(x => x, direction);
        }
        ```

- [**.Shuffle()**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions/Extensions/ShuffleExtensions.cs) - Randomly shuffles a sequence using [Fisher-Yates shuffle](https://en.wikipedia.org/wiki/Fisher-Yates_shuffle). Allows for a predefined randomizer seed for deterministic results.

- And others.

## More packages

![more.jpg](https://github.com/BitzArt/LinqExtensions/blob/main/assets/more.jpg?raw=true)

- [**BitzArt.LinqExtensions.Batching**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions.Batching) - Extension methods for sequence batching.

- [**BitzArt.LinqExtensions.Conditional**](https://github.com/BitzArt/LinqExtensions/blob/main/src/BitzArt.LinqExtensions.Conditional) - LINQ extension methods for more complex conditional operations.