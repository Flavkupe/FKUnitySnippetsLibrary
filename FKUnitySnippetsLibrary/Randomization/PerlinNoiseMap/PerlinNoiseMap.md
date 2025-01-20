### Perlin Noise Map
Perlin Noise is a good tool to generate somewhat structured random data, and it's used quite a bit in game development for many things, as texture and fog effects (though this only scratches the surface).

Unity has a built-in function to gather Perlin Noise: `Mathf.PerlinNoise`. This `PerlinNoiseMap` utility gives you some handy parameters to generate a 2D map of Perlin Noise which can be used for many things.

In the Demo example, I generate a 100x100 tile map based on threshold values of Perlin Noise. With some small bit of tweaking, you might see how this could be used to generate things like cave structures. Sky's the limit!

Play around with the various offset, threshold and scale values to see how you can generate slightly different structures.