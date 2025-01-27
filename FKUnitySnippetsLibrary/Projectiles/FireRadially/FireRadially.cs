using FKUnitySnippets.Transformations;
using FKUnitySnippetsLibrary.Transformations;
using UnityEngine;

namespace FKUnitySnippetsLibrary.Projectiles
{
    public class FireRadially : MonoBehaviour
    {
        [SerializeField]
        private Projectile _projectilePrefab;

        [SerializeField]
        private bool _looping = false;

        [SerializeField]
        private int _numberOfProjectiles = 8;

        [Tooltip("If the value is anything other than 0, the projectiles will spin around the center of this object as well as moving outward.")]
        [SerializeField]
        private float _projectileGroupRotation = 0;

        [SerializeField]
        private float _projectileSpeed = 5.0f;

        [SerializeField]
        private float _projectileLifetime = 5.0f;

        [SerializeField]
        private float _projectileCooldown = 3.0f;

        [SerializeField]
        private float _startDelay = 0.0f;

        [SerializeField]
        private bool _randomStartPosition = false;

        void Start()
        {
            Invoke(nameof(ResetState), _startDelay);
        }

        public void Fire()
        {
            if (_projectilePrefab == null || _numberOfProjectiles == 0)
            {
                return;
            }

            float angleStep = 360f / _numberOfProjectiles;
            float angle = 0f;

            if (_randomStartPosition)
            {
                angle = Random.Range(0, 360);
            }

            // put the projectiles on an object that can spin around for spinning effect;
            // this can also be used to ensure all the projectiles are disposed together by
            // destroying the host object
            var projectileHost = new GameObject("ProjectileHost");
            projectileHost.transform.position = transform.position;
            Destroy(projectileHost, _projectileLifetime);

            if (_projectileGroupRotation != 0.0f)
            {
                var spinner = projectileHost.AddComponent<SpinningObject>();
                spinner.SetRotationSpeed(_projectileGroupRotation);
                spinner.SetRotationAxis(Vector3.forward);
            }

            for (int i = 0; i < _numberOfProjectiles; i++)
            {
                var projectileDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                var projectileDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
                var projectileVector = new Vector3(projectileDirX, projectileDirY, 0);
                var projectileMoveDirection = (projectileVector - transform.position).normalized * _projectileSpeed;

                var projectile = Instantiate(_projectilePrefab, projectileHost.transform);
                projectile.transform.localPosition = projectileMoveDirection * 0.1f;

                var movement = projectile.gameObject.AddComponent<MoveAwayFrom>();
                movement.SetCenterPosition(transform.position);
                movement.SetSpeed(_projectileSpeed);

                angle += angleStep;
            }
        }

        public void ResetState()
        {
            CancelInvoke(nameof(Fire));

            if (_looping)
            {
                InvokeRepeating(nameof(Fire), 0, _projectileCooldown);
            }
            else
            {
                Fire();
            }
        }

        void OnEnable()
        {
            Invoke(nameof(ResetState), _startDelay);
        }

        void OnDisable()
        {
            CancelInvoke(nameof(Fire));
        }
    }
}