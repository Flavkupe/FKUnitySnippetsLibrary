using UnityEngine;

namespace FKUnitySnippetsLibrary.Transformations
{
    public class MoveAwayFrom : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _centerPosition;

        [SerializeField]
        private float _speed;

        public void SetCenterPosition(Vector3 centerPosition)
        {
            _centerPosition = centerPosition;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void Update()
        {
            transform.position += (transform.position - _centerPosition).normalized * _speed * Time.deltaTime;
        }
    }
}