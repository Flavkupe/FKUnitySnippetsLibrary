using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FKUnitySnippets.Probability
{
    [Serializable]
    public class WeightedEntry<T>
    {
        public T Item { get; set; }

        public float Weight = 1.0f;
    }

    public class WeightedList<T>
    {
        private List<WeightedEntry<T>> _entries = new();

        private float _totalWeight;

        public WeightedList(IEnumerable<WeightedEntry<T>> entries)
        {
            AddEntries(entries);
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public void AddEntries(IEnumerable<WeightedEntry<T>> entries)
        {
            _entries.AddRange(entries);
            _entries.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            _totalWeight = _entries.Sum(entry => entry.Weight);
        }

        /// <summary>
        /// Applies the transform function to all weights in the list.
        /// </summary>
        /// <param name="transformFunction"></param>
        public void AdjustWeights(Func<float, float> transformFunction)
        {
            var totalWeight = 0.0f;
            foreach (var entry in _entries)
            {
                entry.Weight = transformFunction(entry.Weight);
                totalWeight += entry.Weight;
            }

            _totalWeight = totalWeight;
        }

        public T GetRandomItem()
        {
            if (_entries.Count == 0)
            {
                return default;
            }

            return GetRandom(_entries).Item;
        }

        /// <summary>
        /// Note: this is a good method to have as an extension function in your project,
        /// but I inlined it here to keep this code self-contained.
        /// </summary>
        private TValue GetRandom<TValue>(IList<TValue> list)
        {
            if (list == null || list.Count == 0)
            {
                return default;
            }

            var random = UnityEngine.Random.Range(0, list.Count);
            return list[random];
        }

        public T GetWeightedRandomItem()
        {
            float randomWeightPoint = UnityEngine.Random.Range(0, _totalWeight);
            float accumulatedWeight = 0;

            foreach (var entry in _entries)
            {
                accumulatedWeight += entry.Weight;
                if (accumulatedWeight >= randomWeightPoint)
                {
                    return entry.Item;
                }
            }

            // fallback
            Debug.LogWarning("No item was selected. This should not happen if the weights are set up correctly.");
            return GetRandomItem();
        }
    }
}