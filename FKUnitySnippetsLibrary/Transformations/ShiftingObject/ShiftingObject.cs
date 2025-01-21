using UnityEngine;

namespace FKUnitySnippets.Transformations
{
    public class ShiftingObject : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;

        [SerializeField]
        private Vector3 _direction = Vector3.up;


        private Vector3 _startPosition;


        private void Start()
        {
            _startPosition = transform.position;
        }

        public void Update()
        {
            transform.position += _direction * _speed * Time.deltaTime;
        }

        public void ResetState()
        {
            transform.position = _startPosition;
        }
    }
}