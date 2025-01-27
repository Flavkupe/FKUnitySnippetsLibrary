

using FKUnitySnippets.Curves;
using System.Collections;
using UnityEngine;

namespace FKUnitySnippetsLibrary.Projectiles
{
    public class ArcProjectile : Projectile
    {
        [SerializeField]
        private float _arcHeight = 1.0f;

        private float _speed;


        public override void LaunchProjectileAt(Vector3 source, Vector3 target, float speed)
        {
            _speed = speed;
            StartCoroutine(TravelInArc(source, target));
        }

        private IEnumerator TravelInArc(Vector3 source, Vector3 target)
        {
            var start = source;
            var end = target;
            var mid = (start + end) / 2.0f;
            mid.y += _arcHeight;

            var bezier = new Bezier(start, mid, end);

            var time = 0.0f;
            while (time < 1.0f)
            {
                time += Time.deltaTime * _speed;
                var position = bezier.GetPoint(time);
                var direction = bezier.GetDirection(time);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                this.transform.position = position;
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                yield return null;
            }

            // destry the projectile when it reaches the target point (assuming it hasn't hit anything first)
            this.DestroyProjectile();
        }
    }
}