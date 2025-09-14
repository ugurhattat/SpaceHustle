using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SpaceHustle.Core
{
    public abstract class GenericPool<T> : MonoBehaviour where T : Component
    {
        [Header("Pool Setup")]
        [SerializeField] protected T[] prefabs;
        [SerializeField] protected int prewarmCount = 10;

        protected readonly Queue<T> pool = new Queue<T>();

        private void Awake()
        {
            SingletonObject();
        }

        //private void OnEnable()
        //{
        //    if (GameManager.Instance != null)

        //        GameManager.Instance.OnSceneChanged += ResetAllObjects;
        //}

        //private void OnDisable()
        //{
        //    if (GameManager.Instance.OnSceneChanged -= ResetAllObjects;)
        //}

        private void Start()
        {
            GrowPool();
        }

        public T Get()
        {
            if (pool.Count == 0) GrowPool();
            return pool.Dequeue();
        }

        public void Set(T item)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(transform);
            pool.Enqueue(item);
        }

        public abstract void ResetAllObjects();
        protected abstract void SingletonObject();

        private void GrowPool()
        {
            if (prefabs == null || prefabs.Length == 0)
            {
                Debug.LogError($"[{name}] Pool 'prefabs' bos! Inspector'a en az 1 prefab ekleyin.");
                return;
            }

            for (int i = 0; i < prewarmCount; i++)
            {
                var prefab = prefabs[Random.Range(0, prefabs.Length)];
                var obj = Instantiate(prefab, transform);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }
    }
}

