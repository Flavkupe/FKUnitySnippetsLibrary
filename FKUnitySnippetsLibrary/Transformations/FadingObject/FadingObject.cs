using System.Collections;
using UnityEngine;

namespace FKUnitySnippets.Transformations
{
    public class FadingObject : MonoBehaviour
    {
        [Tooltip("How quickly the object will fade out.")]
        [SerializeField]
        private float _fadeSpeed = 1f;

        [Tooltip("If true, the object will be destroyed when fully faded out.")]
        [SerializeField]
        private bool _destroyOnFadeOut = false;

        [Tooltip("If true, the object will fade out automatically on start.")]
        [SerializeField]
        private bool _autoFadeOut = true;

        private Coroutine _coroutine;

        private Material _material;
        private Color _originalColor;

        private void Start()
        {
            _material = GetComponent<Renderer>().material;
            _originalColor = _material.color;

            if (_autoFadeOut)
            {
                FadeOut();
            }
        }

        public void FadeOut()
        {
            StopFade();

            _coroutine = StartCoroutine(FadeOutCoroutine());
        }

        public void FadeIn()
        {
            StopFade();

            _coroutine = StartCoroutine(FadeInCoroutine());
        }

        public void StopFade()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void ResetState()
        {
            StopFade();
            _material.color = _originalColor;
            if (_autoFadeOut)
            {
                FadeOut();
            }
        }

        private IEnumerator FadeOutCoroutine()
        {
            while (_material.color.a > 0)
            {
                var c = _material.color;
                _material.color = new Color(c.r, c.g, c.b, c.a - _fadeSpeed * Time.deltaTime);
                yield return null;
            }

            if (_destroyOnFadeOut)
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator FadeInCoroutine()
        {
            while (_material.color.a < 1)
            {
                var c = _material.color;
                _material.color = new Color(c.r, c.g, c.b, c.a + _fadeSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}