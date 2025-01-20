using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FKUnitySnippets.ExtensionFunctions
{
    public static class ExtensionFunctions
    {
        public static void DestroyChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                UnityEngine.Object.Destroy(child.gameObject);
            }
        }
    }

    public static class Vector3Extensions
    {
        public static Vector3 MoveX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 ShiftY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }

        public static Vector3 ShiftX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }

        public static Vector3 ShiftXY(this Vector3 vector, float x, float y)
        {
            return new Vector3(vector.x + x, vector.y + y, vector.z);
        }

        public static Vector3 SetXY(this Vector3 vector, float x, float y)
        {
            return new Vector3(x, y, vector.z);
        }

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        public static bool IsWithinDistance(this Vector3 source, Vector3 target, float distance = 0.1f)
        {
            return Vector3.Distance(source, target) <= distance;
        }
    }

    public static class RandomizationExtensions
    {
        /// <summary>
        /// Gets a random value between the vector's x and y values.
        /// This is especially useful when using a Vector2 to easily define a range
        /// in the Inspector.
        /// inclusive.
        /// </summary>
        public static float RandRange(this Vector2 vector)
        {
            return UnityEngine.Random.Range(vector.x, vector.y);
        }
    }

    public static class ListExtensions
    {
        /// <summary>
        /// Gets a random value from the list. If the list is empty, returns
        /// the default value.
        /// </summary>
        public static TValue GetRandom<TValue>(this IList<TValue> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            var random = UnityEngine.Random.Range(0, list.Count);
            return list[random];
        }

        /// <summary>
        /// Shuffles the provided list. Returns the same instance of the list, shuffled.
        /// </summary>
        public static IList<TValue> GetShuffled<TValue>(this IList<TValue> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var randomIndex = UnityEngine.Random.Range(0, list.Count - 1);
                var temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            return list;
        }

        /// <summary>
        /// Gets the element that has the maximum value from the provided predicate (as opposed
        /// to just fetching the value itself, which is what LINQ's Max() does).
        /// </summary>
        public static T WithMaxValue<T, R>(this IList<T> source, Func<T, R> predicate) where R : IComparable
        {
            if (source.Count() == 0)
            {
                return default;
            }

            var max = source[0];
            var maxValue = predicate(max);
            foreach (var item in source)
            {
                var value = predicate(item);
                if (maxValue == null || value.CompareTo(maxValue) > 0)
                {
                    maxValue = value;
                    max = item;
                }
            }

            return max;
        }


        /// <summary>
        /// Gets the element that has the minimum value from the provided predicate (as opposed
        /// to just fetching the value itself, which is what LINQ's Min() does).
        /// </summary>
        public static T WithMinValue<T, R>(this IList<T> source, Func<T, R> predicate) where R : IComparable
        {
            if (source.Count() == 0)
            {
                return default;
            }

            var min = source[0];
            var minValue = predicate(min);
            foreach (var item in source)
            {
                var value = predicate(item);
                if (minValue == null || value.CompareTo(minValue) < 0)
                {
                    minValue = value;
                    min = item;
                }
            }

            return min;
        }
    }

    public static class DictionaryExtensions
    {
        public static R GetValueOrDefault<T, R>(this IDictionary<T, R> dict, T key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }

            return default;
        }

        /// <summary>
        /// Sets the value of the key in the dictionary, or adds to that value if the
        /// value already exists.
        /// </summary>
        public static void SetOrAddTo<T>(this IDictionary<T, int> dict, T key, int val)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = val;
            }
            else
            {
                dict[key] += val;
            }
        }
    }
}