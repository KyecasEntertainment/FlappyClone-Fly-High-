using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float obstacleSpeed = 2f;
    public float obstacleLifetime = 10f;
    public float heightVariation;
    public PlayerMovementScript playerMovementScript;
    public PointingSystemScript pointingSystemScript;



    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(pointingSystemScript.spawnInterval);
        }
    }
    void SpawnObstacle()
    {
        if (!playerMovementScript.isGrounded)
        {
            float randomHeight = Random.Range(-1.5f, 3.3f);
            Vector2 spawnPosition = new Vector2(5, transform.position.y + randomHeight);

            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        }
        else
        {
            return;
        }
    }


}
