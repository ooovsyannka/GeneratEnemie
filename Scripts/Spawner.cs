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
            enemy.transform.rotation = GetRandomRotation();
            enemy.transform.position = _spawnPoint.position;
            enemy.gameObject.SetActive(true);
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private Quaternion GetRandomRotation()
    {
        float maxAngelY = 360;
        float randomAngely = Random.Range(0, maxAngelY);

        return Quaternion.Euler(0, randomAngely, 0);
    }
}