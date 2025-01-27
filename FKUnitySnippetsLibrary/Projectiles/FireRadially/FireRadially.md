### Fire Radially
These scripts show how you can fire projectiles in a circle around a target. These sorts of patterns are quite common in bullet hell games.

With a bit of creativity you can do quite a bit with these sorts of patterns. For example, you could have the projectiles fire in a spiral pattern, or have bullets explode into a circle of other bullets.

Note that some demos use the script `MoveAwayFrom` to allow the bullets to always move away from the starting point; this is helpful in scenarios where we are also making the bullets rotate, whereby simply giving them a direction will likely not yield the results we want.

The demos show the following scenarios:

1. Shooting bullets evenly in all directions around a target.		
2. Shooting bullets in a rotating circle around the target, like a spinning wheel of bullets.
3. Shooting bullets that then explode into a circle of other bullets.
4. Setting random starting positions for the bullets to create less uniform patterns.
