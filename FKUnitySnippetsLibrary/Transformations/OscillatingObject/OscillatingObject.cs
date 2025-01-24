using UnityEngine;

namespace FKUnitySnippets.Transformations
{
    public class OscillatingObject : MonoBehaviour
    {
        private float _period = 0.0f;

        [SerializeField]
        private float _speed = 1.0f;

        [SerializeField]
        private float _magnitude = 1.0f;

        [Tooltip("Whether to use cosine instead of sine.")]
        [SerializeField]
        private bool _useCos = false;

        [SerializeField]
        private Vector3 _axis = Vector3.up;

        private Vector3 _originalPos;

        public void ResetState()
        {
            this.transform.localPosition = _originalPos;
            _period = 0.0f;
        }

        void Start()
        {
            _originalPos = this.transform.localPosition;
        }

        void Update()
        {
            _period = (_period + _speed * Time.deltaTime) % (2 * Mathf.PI);
            var value  = _useCos ? Mathf.Cos(_period) : Mathf.Sin(_period);
            value = Mathf.Abs(value * _magnitude);
            this.transform.localPosition = _originalPos + this._axis * value;
        }
    }
}