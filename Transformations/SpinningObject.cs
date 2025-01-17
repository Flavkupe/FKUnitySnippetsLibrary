using UnityEngine;

namespace FKUnitySnippets.Movement.Rotation
{
    public class SpinningObject : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed = 1f;

        [SerializeField]
        private Vector3 _axis = Vector3.up;

        private void Update()
        {
            transform.Rotate(_axis, _rotationSpeed * Time.deltaTime);
        }
    }
}
