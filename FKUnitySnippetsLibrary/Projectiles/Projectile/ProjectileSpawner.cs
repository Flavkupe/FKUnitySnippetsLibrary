
using UnityEngine;

namespace FKUnitySnippetsLibrary.Projectiles
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField]
        private Projectile _projectilePrefab;

        [SerializeField]
        private float _projectileSpeed = 5.0f;

        public float ProjectileSpeed => _projectileSpeed;

        protected Projectile SpawnProjectile()
        {
            return Instantiate(_projectilePrefab, this.transform.position, Quaternion.identity);
        }

        public void LaunchAtPlayer()
        {
            // this is just one way to find who the player is; you might have a different way,
            // such as having a singleton that holds the value
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                return;
            }

            LaunchProjectileAt(player.transform.position);
        }

        public void LaunchProjectileAt(Vector3 target)
        {
            var projectile = SpawnProjectile();
            projectile.LaunchProjectileAt(this.transform.position, target, _projectileSpeed);
        }
    }
}
