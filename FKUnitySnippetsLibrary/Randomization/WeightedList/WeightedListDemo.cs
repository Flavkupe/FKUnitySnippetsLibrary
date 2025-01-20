using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace FKUnitySnippets.Randomization
{
    [Serializable]
    public class WeightedItem
    {
        public string Name;
        public float Weight = 1.0f;
        public Sprite Icon;
    }

    public class WeightedListDemo : MonoBehaviour
    {
        private WeightedList<WeightedItem> _weightedList;

        [SerializeField]
        private WeightedItem[] _items;

        private LayoutGroup _resultDisplay;

        private void Start()
        {
            var items = _items.Select(_items => new WeightedEntry<WeightedItem> { Item = _items, Weight = _items.Weight });
            _weightedList = new WeightedList<WeightedItem>(items);

            _resultDisplay = GetComponentInChildren<LayoutGroup>();
        }

        public void GenerateItems(bool weighted)
        {
            DestroyChildren(_resultDisplay.transform);
            var items = new List<WeightedItem>();
            for (var i = 0; i < 100; i++)
            {
                if (weighted)
                {
                    items.Add(_weightedList.GetWeightedRandomItem());
                }
                else
                {
                    items.Add(_weightedList.GetRandomItem());
                }
                
            }

            // sort by weight (ascending)
            items.Sort((a, b) => (int)(a.Weight - b.Weight));

            // add icons to the layout for the items being displayed
            foreach (var item in items)
            {
                var itemObject = new GameObject(item.Name);
                var image = itemObject.AddComponent<Image>();
                image.sprite = item.Icon;
                itemObject.transform.SetParent(_resultDisplay.transform);
            }
        }

        public void DestroyChildren(Transform transform)
        {
            foreach (Transform child in transform)
            {
                if (child != null)
                {
                    UnityEngine.Object.Destroy(child.gameObject);
                }
            }
        }
    }
}
