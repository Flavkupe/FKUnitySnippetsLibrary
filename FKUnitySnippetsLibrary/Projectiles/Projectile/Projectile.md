### Projectile and Projectile Spawners
In this section, you can see implementations of an extensible `Projectile` class, along with one alternative implementation, `ArcProjectile`, which uses Bezier curves to throw the projectile in an arc.

To use these Projectiles, this demo introduces a nifty component called a `ProjectileSpawner` which takes a projectile prefab (such as a Bullet or Arrow, each using `Projectile` or `ArcProjectile`) and can spawn those prefabs as needed. Having this as a separate component can be quite handy for several reasons:
1. You can invoke it as needed to fire the necessary projectile at the right time.	
2. Multiple spawners can be used to spawn different types of projectiles from the same source.
3. The spawner can be placed in the center of where you want it to be fired. For example, in this demo you can see the projectile placed in the tip of the enemy's staff to make it look like it's casting these as spells.

The `Projectile` class itself has a `OnDestroyed` event which can be used to configure behaviors that might happen when the projectile is destroyed. This can be used to spawn a new projectile, or to trigger an explosion, or whatever else you might need.

The following demos are shown here:
1. Firing a simple bullet projectile in a line, aimed at the click position.
2. Firing an arc projectile.
3. A projectile that spawns another projectile when it reaches its target.
4. A projectile that spawns a copy of itself when it reaches its target, making it look like it bounces towards the player.

These example show that you can make many creative projectile effects with just these simple components.