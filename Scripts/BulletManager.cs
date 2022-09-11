using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    public int bulletPool = 20;

    private GameObject bulletPrefab;
    private List<GameObject> bullets = new List<GameObject>();

    private void Awake()
    {
        instance = this;

        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");

        CreateBullets();
    }

    private void CreateBullets()
    {
        for(int i = 0; i < bulletPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    public void Fire(Vector2 position)
    {
        foreach(GameObject bullet in bullets)
        {
            if(!bullet.activeSelf)
            {
                bullet.SetActive(true);
                bullet.transform.position = position;

                return;
            }
        }
    }
}
