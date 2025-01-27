### Interfaces
This page shows a collection of helpful interfaces that can help define your components in terms of specific behaviors.

If you're not familiar with interfaces, they are a programming concept where you can define a set of behaviors that objects sharing an interface might have. For example, `IDisposable` is an common interface, which simply states that an object implements the `void Dispose()` method. So if you have a `List<IDisposable>`, it's a list of objects that all have the `void Dispose()` method, so you can do something like this:

```csharp
// NOTE: this is just for illustrative purposes; this is probably not a function
// you would write.
private void DisposeAll(List<IDisposable> items)
{
    foreach (var item in items)
    {
        item.Dispose();
    }
}
```

Since all items in the above `List<IDisposable>` are `IDisposable`, C# allows you to call `Dispose()` on each item, knowing it will be implemented for that item. Notably, the items in this list could be from all sorts of different `class` implementations; that makes this approach especially effective, as no matter what class the objects are, they can call `Dispose` since they implement `IDisposable`.

In C#, interfaces are normally named prefixed with `I`; this is not a language requirement, but it's a standard that is rarely avoided. Some other examples might be `IEnumerable` (you can enumerate through this object), `IComparable` (you can compare two of these objects), etc..

One good example of an interface you might define is `IDamageable`, which has the single method `void TakeDamage(int damage)`. This allows you to use `IDamageable` to define things that can be damaged by attacks in the game.

#### When and how, to use interfaces
Proper use of interfaces across your project, while not required, is a highly effective way to keep things easy to maintain. It can also take a fair amount of practice and experience to know when to use interfaces, and how those interfaces should look.

It's generally helpful to adhere to the [Interface Segregation Principle](https://en.wikipedia.org/wiki/Interface_segregation_principle) when defining your interfaces. This basically states that interfaces should be small and concise, focusing on a very specific definition.