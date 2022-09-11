using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public int EnemyPool = 10;

    private GameObject enemyPrefab;
    private List<GameObject> enemies = new List<GameObject>();

    private float time = 0;
    public float spawnTime = 1.0f;

    private void Awake()
    {
        instance = this;

        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");

        CreateEnemies();
    }

    private void Update()
    {
        time += Time.deltaTime;

        if(time > spawnTime)
        {
            time -= spawnTime;

            Spawn();
        }
    }

    private void CreateEnemies()
    {
        for(int i = 0; i < EnemyPool; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);

            enemies.Add(enemy);
        }
    }

    private void Spawn()
    {
        foreach(GameObject enemy in enemies)
        {
            if(!enemy.activeSelf)
            {
                float posX = Random.Range((float)-4.5, (float)4.5);
                Vector2 temp;
                temp.x = posX;
                temp.y = 11;

                enemy.SetActive(true);
                enemy.transform.position = temp;

                return;
            }
        }
    }
}
