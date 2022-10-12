using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class obstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    void Start()
    {
        StartCoroutine(SpawObstacle());
    }

   private IEnumerator SpawObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            float mindTime = 0.6f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(mindTime, maxTime);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(randomTime);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
