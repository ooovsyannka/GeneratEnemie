using System.Collections;
using UnityEngine;

public class PortalHolder : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private float _delay = 2;

    private void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    private IEnumerator SpawnNewEnemy()
    {
        bool isWork = true;

        while (isWork)
        {
            yield return new WaitForSeconds(_delay);

            GetRandomSpawner().Spawn();
        }
    }

    private Spawner GetRandomSpawner()
    {
        int randomSpawnerIndex = Random.Range(0, _spawners.Length);

        return _spawners[randomSpawnerIndex];
    }
}
