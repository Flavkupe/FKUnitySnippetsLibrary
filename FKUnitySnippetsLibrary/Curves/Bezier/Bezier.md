### Bezier Curves
You can use Bezier curves to represent an "arc", like an arrow shooting up and back down. You can get a similar parabolic effect by using physics and gravity, but Bezier curves are simple and effective ways to plot the trajectory of an object through an arc.

The basic things about the `Bezier.cs` script:

1. The object goes from `_t` == 0.0f (start point) to `_t` == 1.0f (end point). The speed at which `_t` goes up indicates how quickly the object moves.
2. There are 3 `Vector3` points defining the curve: `p0`, `p1` and `p2`. `p0` is the start point and `p2` is the end point. `p1` is some point in the middle that determines how far up or down the object will curve. It doesn't need to be at the midpoint between `p0` and `p2`, though this Demo script uses that to make a symmetrical arc.
3. You can use the derivative of the arc to make the object point in the direction that it is facing. This Demo uses this to make the arrow point in the correct direction.