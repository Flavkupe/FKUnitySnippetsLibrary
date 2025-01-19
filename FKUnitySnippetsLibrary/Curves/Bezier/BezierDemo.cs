using System.Security.Cryptography;
using UnityEngine;

namespace FKUnitySnippets.Curves.Bezier
{
    public class BezierDemo : MonoBehaviour
    {
        [Tooltip("Which object is moving along the curve.")]
        [SerializeField]
        private GameObject _targetObject;

        [Tooltip("End point of the curve.")]
        [SerializeField]
        private Vector3 _targetPoint;

        [Tooltip("Starting point of the curve.")]
        [SerializeField]
        private Vector3 _startingPoint;

        [Tooltip("How far up (or down, if negative) the middle of the curve is.")]
        [SerializeField]
        private float _controlPointOffset = 0.0f;

        [Tooltip("Travel speed of object.")]
        [SerializeField]
        private float _speed = 1.0f;

        [Tooltip("If true, the object will rotate in the direction of movement.")]
        [SerializeField]
        private bool _turnInMovementDirection = true;

        [Tooltip("If true, the position will reset to the starting point when the target is reached.")]
        [SerializeField]
        private bool _looping = true;

        private float _t = 0.0f;

        private Bezier _bezier;

        private void Start()
        {
            ResetState();   
        }

        public void ResetState()
        {
            _t = 0.0f;
            var midpoint = (_startingPoint + _targetPoint) / 2;
            _bezier = new Bezier(_startingPoint, midpoint + Vector3.up * _controlPointOffset, _targetPoint);
        }

        public void Reverse()
        {
            _speed *= -1;
        }

        private void Update()
        {
            // the temporary variable can allow _speed to change to negative to reverse the direction
            // after the destination is reached
            var t = _t + Time.deltaTime * _speed;
            if (t < 0.0f || t > 1.0f)
            {
                if (_looping)
                {
                    ResetState();
                }

                return;
            }

            _t = t;
            var point = _bezier.GetPoint(_t);
            _targetObject.transform.position = point;

            if (_turnInMovementDirection)
            {
                Vector3 direction = _bezier.GetDirection(_t);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _targetObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                // NOTE: The following also works the same as above; however, due to how Quaternion.LookRotation works,
                // it requires the additional rotation below to make it work properly in 2D.
                // _targetObject.rotation = Quaternion.LookRotation(_bezier.GetDirection(_t));
                // _targetObject.Rotate(0, 90, 180);
            }
        }
    }
}
