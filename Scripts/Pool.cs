using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _maxCount;

    private Queue<Enemy> _pool = new Queue<Enemy>();

    private void Start()
    {
        for (int i = 0; i < _maxCount; i++)
        {
            Enemy enemy = Instantiate(_enemy);

            enemy.gameObject.SetActive(false);
            _pool.Enqueue(enemy);
        }
    }

    public bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _pool.Dequeue();
        _pool.Enqueue(enemy);

        return  enemy.gameObject.activeInHierarchy == false;
    }
}