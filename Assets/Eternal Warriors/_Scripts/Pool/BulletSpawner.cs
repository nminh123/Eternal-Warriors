using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public PoolObject bulletPool;
    public Transform bulletPoint;
    


    public void FireBullet()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = bulletPoint.position;
        bullet.transform.rotation = bulletPoint.rotation;
    }
}
