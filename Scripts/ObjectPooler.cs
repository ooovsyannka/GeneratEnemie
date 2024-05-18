using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int MaxSize;
        public Enemy Enemy;
        public TypeEnemy TypeEnemy;
    }

    [SerializeField] private List<Pool> _pools;
    private Dictionary<TypeEnemy, Queue<Enemy>> _poolDictionary;

    private void Start()
    {
        _poolDictionary = new Dictionary<TypeEnemy, Queue<Enemy>>();

        foreach (Pool pool in _pools)
        {
            Queue<Enemy> objectPool = new Queue<Enemy>();

            for (int i = 0; i < pool.MaxSize; i++)
            {
                Enemy currentEnemy = Instantiate(pool.Enemy);
                currentEnemy.gameObject.SetActive(false);
                objectPool.Enqueue(currentEnemy);
            }

            _poolDictionary.Add(pool.TypeEnemy, objectPool);
        }
    }

    public bool TryGetEnemy(out Enemy enemy, TypeEnemy desiredType)
    {
        enemy = null;

        if (_poolDictionary.ContainsKey(desiredType))
        {
            enemy = _poolDictionary[desiredType].Dequeue();
            _poolDictionary[desiredType].Enqueue(enemy);

            return enemy.gameObject.activeInHierarchy == false;
        }

        return false;
    }
}