using UnityEngine;

namespace FKUnitySnippets.Transformations
{
    /// <summary>
    /// Note: You can remove the ICanReset if you just want the code snippet on its own.
    /// </summary>
    public class OscillatingObject : MonoBehaviour, ICanReset
    {
        private float _period = 0.0f;

        [SerializeField]
        private float _speed = 1.0f;

        [SerializeField]
        private float _magnitude = 1.0f;

        [SerializeField]
        private Vector3 _axis = Vector3.up;

        private Vector3 _originalPos;

        public void Reset()
        {
            this.transform.localPosition = _originalPos;
            _period = 0.0f;
        }

        void Start()
        {
            _originalPos = this.transform.localPosition;
        }

        // Update is called once per frame
        void Update()
        {
            _period = (_period + _speed * Time.deltaTime) % (2 * Mathf.PI);

            var cos = Mathf.Abs(Mathf.Cos(_period) * _magnitude);
            this.transform.localPosition = _originalPos + this._axis * cos;
        }
    }
}