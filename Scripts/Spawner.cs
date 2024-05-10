using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private Transform _spawnPoint;

    public void Spawn()
    {
        Enemy enemy;

        if (_pool.TryGetEnemy(out enemy))
        {
            enemy.SetDirection(GetRandomDirection());
            enemy.transform.position = _spawnPoint.position;
            enemy.gameObject.SetActive(true);
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private Vector3 GetRandomDirection()
    {
        Vector3 direction = Vector3.zero;

        while (direction == Vector3.zero)
        {
            float randomDirectionX = Random.Range(-1, 2);
            float randomDirectionZ = Random.Range(-1, 2);

            direction = new Vector3(randomDirectionX, 0, randomDirectionZ);
        }

        return direction;
    }
}