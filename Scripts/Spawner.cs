using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private ObjectPooler _pooler;
    [SerializeField] private TypeEnemy _typeEnemy;

    private void Start()
    {
        StartCoroutine(SpawnNewEnemys());
    }

    private IEnumerator SpawnNewEnemys()
    {
        float minDelay = 3f;
        float maxDelay = 6f;
        bool isWork = true;

        while (isWork)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(Random.Range(minDelay, maxDelay));

            yield return waitForSeconds;
            Spawn();
        }
    }

    private void Spawn()
    {
        Enemy enemy;

        if (_pooler.TryGetEnemy(out enemy, _typeEnemy))
        {
            enemy.gameObject.SetActive(true);
            enemy.transform.position = new Vector3(transform.position.x, enemy.transform.position.y, transform.position.z);
            enemy.SetTarget(_target);
        }
    }
}