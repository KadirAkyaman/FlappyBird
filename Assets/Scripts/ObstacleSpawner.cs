using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    PlayerMovement playerMovement;

    public GameObject obstacle;
    public float maxTime;
    float timer;

    public float maxY;
    public float minY;
    float randomY;
    void Start()
    {
        playerMovement = GameObject.Find("Bird").GetComponent<PlayerMovement>();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime && !playerMovement.isDead && playerMovement.isStart)
        {
            randomY = Random.Range(minY, maxY);
            InstantiateObstacle();
            timer = 0;
        }

    }

    public void InstantiateObstacle()
    {
        GameObject obstaclePrefab = Instantiate(obstacle);
        obstacle.transform.position = new Vector2(transform.position.x, randomY);

    }
}
