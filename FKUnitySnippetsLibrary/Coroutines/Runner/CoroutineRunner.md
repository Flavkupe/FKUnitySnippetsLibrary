### Coroutine Runner
If you're a fan of using Coroutines, the `CoroutineRunner` gives you a way to run a coroutine from classes that are not `MonoBehaviour`.

Here's an example:

~~~csharp
public static class MyUtilityClass
{
	public static void DoSomething()
	{
		CoroutineRunner.Instance.RunCoroutine(MyCoroutine());
	}

	private static IEnumerator MyCoroutine()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("Coroutine finished!");
	}
}
~~~
