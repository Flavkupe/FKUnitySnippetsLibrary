### Catmull-Rom Spline
A popular spline commonly used in animation for smooth interpolation between points.

As setup in this demo, a segment of the spline has 4 points (p0, p1, p2 and p3), and the spline is calculated only between p1 and p2, with p0 and p3 as control points. By adding additional points, it will smoothly travel between them, though notably it will never hit this first and last points in the list.

This spline is very useful for creating smooth paths for objects (including cameras) to follow, and is used in many games and animations.