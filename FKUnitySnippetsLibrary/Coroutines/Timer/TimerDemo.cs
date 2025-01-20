using TMPro;
using UnityEngine;

namespace FKUnitySnippets.Coroutines
{
    public class TimerDemo : MonoBehaviour
    {
        [SerializeField]
        private GameObject _objectToSpawn;

        private Coroutine _intervalCoroutine;

        [SerializeField]
        private TMP_Text _intervalText;

        [SerializeField]
        private float _delayTime = 1.0f;

        public void SpawnObjectNow()
        {
            Instantiate(_objectToSpawn);
        }

        public void SpawnObjectSoon()
        {
            // this works as well, but showing both options for illustration purposes:
            // Timer.Instance.SetTimeout(SpawnObjectNow, 2.0f);

            Timer.Instance.SetTimeout(() =>
            {
                Instantiate(_objectToSpawn);
            }, _delayTime);
        }

        public void StartSpawningObjects()
        {
            // stop existing interval if it exists to avoid
            // multiple intervals running at the same time
            StopSpawningObjects();

            _intervalText.text = "Stop Spawning";
            _intervalCoroutine = Timer.Instance.SetInterval(() =>
            {
                Instantiate(_objectToSpawn);
            }, _delayTime);
        }

        public void StopSpawningObjects()
        {
            if (_intervalCoroutine != null)
            {
                // IMPORTANT: make sure you call StopCoroutine from the same
                // object that started the coroutine. If you don't, you will get errors!
                Timer.Instance.StopCoroutine(_intervalCoroutine);
                _intervalCoroutine = null;
                _intervalText.text = "Spawn Repeatedly";
            }
        }

        public void ToggleIntervalSpawns()
        {
            if (_intervalCoroutine == null)
            {
                StartSpawningObjects();
            }
            else
            {
                StopSpawningObjects();
            }
        }
    }
}
