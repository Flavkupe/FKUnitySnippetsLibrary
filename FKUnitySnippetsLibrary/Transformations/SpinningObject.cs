using UnityEngine;

namespace FKUnitySnippets.Transformations
{
    public class SpinningObject : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 1f;

        [SerializeField]
        private Vector3 _axis = Vector3.up;

        private Quaternion _originalRotation;

        private void Start()
        {
            _originalRotation = transform.rotation;
        }

        private void Update()
        {
            transform.Rotate(_axis, _rotationSpeed * Time.deltaTime);
        }

        public void ResetState()
        {
            transform.rotation = _originalRotation;
        }
    }
}
