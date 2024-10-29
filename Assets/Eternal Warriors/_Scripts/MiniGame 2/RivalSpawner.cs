using UnityEngine;
using Random = UnityEngine.Random;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class RivalSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float maxX, minX, maxY, minY, timeBetweenSpawn;
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
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            Instantiate(prefab, transform.position + new Vector3(x, y, 0), transform.rotation);
        }
    }
}