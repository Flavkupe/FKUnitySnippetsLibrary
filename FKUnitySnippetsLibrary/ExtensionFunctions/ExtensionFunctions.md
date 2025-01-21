### Extension Functions
Extension Functions can save you a ton of time and effort writing code. If you are not familiar with the concept, an Extension Function basically allows you to define a method that you can use on any class that exists, even one you didn't write yourself (in fact, this is the most likely application of it).

The library `System.Linq` includes a bunch of very useful extension functions that you can use on any `IEnumerable` object such as `List`. The `ExtensionFunctions.cs` file similarly includes a bunch of ExtensionFunctions I've accumulated over time for various Unity projects.

If you aren't familiar with the usage of extension functions, here's an example of how you'd use `MoveX` on a Vector3 object (**NOTE: don't forget to include the namespace that the Extension Functions are in!):

~~~csharp
using UnityEngine;

// IMPORTANT: Make sure to include the namespace of the Extension Functions!
using FKUnitySnippets.ExtensionFunctions;

public class Example : MonoBehaviour
{
	void Start()
	{
		Vector3 position = new Vector3(1, 2, 3);
		position = position.MoveX(5);
		Debug.Log(position); // Output: (5, 2, 3)
	}
}
~~~

You can always create your own Extension functions as well. Here's an example of how you'd create an Extension Function for the `Vector3` class:

~~~csharp
using UnityEngine;

public static class MyVector3Extensions
{
	// this operates on a Vector3 object and takes x as an argument
	public static Vector3 MyExtensionFunction(this Vector3 vector, float x)
	{
		// do something with the vector
	}
}
~~~