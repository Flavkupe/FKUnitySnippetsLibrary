### Timer
This timer implementation gives you some very handy utility functions to create delayed or repeated actions.

- `SetTimeout` allows you to configure a delayed action.
- `SetInterval` allows you to configure a repeated action.
- `DoNextFrame` is a more niche helper that can be very useful in specific cases.

The demo also shows how you can cancel a repeated action.

You might wonder why this needs to be a MonoBehaviour? This is because Coroutines must be started from MonoBehaviour instances. However, this doesn't *need* to be a Singleton; a Timer can be attached to each component that needs one. You can also create a static implementation of this which passes the source MonoBehaviour into each of the methods and starts the Coroutines from there.

You can also design this to not use Coroutines at all, though using Coroutines for this is very clean and simple.
