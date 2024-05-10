using System.Collections;
using UnityEngine;

public class PortalHolder : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private WaitForSeconds _waitForSeconds;
    private float _delay = 2;

    private void Start()
    {
        StartCoroutine(Coldown());
    }

    private IEnumerator Coldown()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        bool isWork = true;

        while (isWork)
        {
            yield return _waitForSeconds;

            GetRandomSpawner().Spawn();
        }
    }

    private Spawner GetRandomSpawner()
    {
        int randomSpawnerIndex = Random.Range(0, _spawners.Length);

        return _spawners[randomSpawnerIndex];
    }
}
