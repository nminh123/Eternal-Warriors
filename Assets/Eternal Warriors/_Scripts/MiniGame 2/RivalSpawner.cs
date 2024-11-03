using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class RivalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float timeBetweenSpawn;
        private float spawnTime;

        private void Update()
        {
            if (Time.deltaTime > spawnTime)
            {
                Spawn();
                spawnTime = Time.deltaTime + timeBetweenSpawn;
            }
        }

        void Spawn()
        {
            Instantiate(prefab, transform.position + new Vector3(Random.Range(3.64f, 8.5f), Random.Range(-22.5f,135f), 0), transform.rotation);
        }
    }
}