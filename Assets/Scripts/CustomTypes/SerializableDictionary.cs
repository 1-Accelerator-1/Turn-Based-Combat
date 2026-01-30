using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CustomTypes
{
    [Serializable]
    public class SerializableDictionary<K, V>
    {
        [Serializable]
        private class CustomDictionaryPair
        {
            [SerializeField] public K Key;
            [SerializeField] public V Value;
        }

        [SerializeField] private CustomDictionaryPair[] thisDictionaryPairs;

        public Dictionary<K, V> ToDictionary()
        {
            var customDictionary = new Dictionary<K, V>();

            foreach (var pair in thisDictionaryPairs)
            {
                customDictionary.Add(pair.Key, pair.Value);
            }

            return customDictionary;
        }
    }
}
