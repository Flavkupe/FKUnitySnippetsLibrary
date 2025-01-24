### Perlin Noise Map
Perlin Noise is a good tool to generate somewhat structured random data, and it's used quite a bit in game development for many things, as texture and fog effects (though this only scratches the surface).

Unity has a built-in function to compute Perlin Noise: `Mathf.PerlinNoise`. The `PerlinNoiseMap` utility I provided gives you some handy parameters to generate a 2D map of Perlin Noise which can be used for many things.

In the Demo example, I generate a 100x100 tile map based on threshold values of Perlin Noise. With some small bit of tweaking, you might see how this could be used to generate things like cave structures. Sky's the limit!

Notice that you can specify a "seed", which generates a totally unique map by randomly generating a large x/y offset for the Perlin Noise function. All the seed value does is set the seed of the random number generator to ensure that every seed produces the exact same map.

Since the values provided by Perlin Noise are floats from 0.0 to 1.0, these can be alternatively mapped to things like height values for terrain generation, or color values for texture generation.

Play around with the various offset, threshold and scale values to see how you can generate slightly different structures.