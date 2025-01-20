using System;
using System.Collections;
using UnityEngine;

namespace FKUnitySnippets.Coroutines.Timer
{
    public class Timer : MonoBehaviour
    {
        private static Timer _instance;

        public static Timer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject("Timer").AddComponent<Timer>();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Sets an action to start after `delay` seconds.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="delay">Seconds to wait until the action.</param>
        /// <returns></returns>
        public Coroutine SetTimeout(Action action, float delay)
        {
            return StartCoroutine(TimeoutCoroutine(action, delay));
        }

        /// <summary>
        /// Sets up an action to be called consistently every `interval` seconds.
        /// </summary>
        /// <param name="action">The action to run.</param>
        /// <param name="interval">Time between actions, in seconds.</param>
        public Coroutine SetInterval(Action action, float interval)
        {
            return StartCoroutine(IntervalCoroutine(action, interval));
        }

        /// <summary>
        /// Does the action in the next frame. This is a bit of a hack but there
        /// are times where it's quite useful. One example is when you know things will
        /// load this frame and you want to wait for those things to load before doing
        /// something (though it's best to setup proper event system for those scenarios).
        /// </summary>
        public void DoNextFrame(Action action)
        {
            StartCoroutine(DoNextFrameCoroutine(action));
        }

        private IEnumerator DoNextFrameCoroutine(Action action)
        {
            yield return null;
            action();
        }

        private IEnumerator TimeoutCoroutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action();
        }

        private IEnumerator IntervalCoroutine(Action action, float interval)
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                action();
            }
        }
    }
}