using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public List<GameObject> prefab;
        public int size;
    }
    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Use this for initialization
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                //loop through the GameObject list inside the pool and instantiate each
                for (int a = 0; a < pool.prefab.Count; a++)
                {
                    GameObject obj = Instantiate(pool.prefab[a]);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }


}
