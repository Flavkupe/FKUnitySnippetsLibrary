using FKUnitySnippetsLibrary.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace FKUnitySnippetsLibrary.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private int _damage = 1;

        [SerializeField]
        private LayerMask _collisionMask;

        [SerializeField]
        private bool _destroyOnCollision = true;

        [Tooltip("Seconds of duration before the projectile is destroyed. Set to 0 for infinite lifetime.")]
        [SerializeField]
        private float _lifetime = 5.0f;

        [SerializeField]
        private UnityEvent _onDestroyed;

        private void Start()
        {
            if (_lifetime > 0)
            {
                Destroy(gameObject, _lifetime);
            }
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            HandleCollision(collision);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleCollision(collision.collider);
        }

        private void HandleCollision(Collider2D collider)
        {
            if (!LayerMaskContains(_collisionMask, collider.gameObject.layer))
            {
                return;
            }

            if (collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(_damage);
            }

            if (_destroyOnCollision)
            {
                DestroyProjectile();
            }
        }

        private bool LayerMaskContains(LayerMask mask, int layer)
        {
            return (mask & (1 << layer)) != 0;
        }


        /// <summary>
        /// This method is virtual, so it can be overridden by a derived class to add different ways of launching
        /// the projectile. The projectile in each case will be launched at a target point, with an optional speed
        /// parameter.
        /// 
        /// This variant launches the projectile in a line towards the target point, but other variants might do
        /// other things like launching the projectile in an arc, or with a homing behavior.
        /// </summary>
        /// <param name="direction"></param>
        public virtual void LaunchProjectileAt(Vector3 source, Vector3 target, float speed)
        {
            var direction = target - source;
            var velocity = direction.normalized * speed;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = velocity;
        }

        /// <summary>
        /// This can be used to provide additional behaviors for when the projectile is destroyed,
        /// such as explosions.
        /// </summary>
        public virtual void DestroyProjectile()
        {
            _onDestroyed.Invoke();
            Destroy(gameObject);
        }
    }
}
