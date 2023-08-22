using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab, enemyPrefab1, enemyPrefab2, enemyPrefab3;
    private bool wavecomplete0, wavecomplete1, wavecomplete2;
    private float spawnRadius = 0.25f; // Adjust as needed
    public float spawnRate = 2f;   // Adjust spawn rate as needed

    private Camera mainCamera;
    private float cameraMargin = 0.25f;

    private float timer = 0f;
    private float nextEnemyTimer = 100f;

    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", spawnRate, spawnRate);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextEnemyTimer)
        {
            if (wavecomplete1 && !wavecomplete2)
            { 
                wavecomplete2 = true;
                wavecomplete1 = true;
                wavecomplete0 = true;
            }
            if (wavecomplete0 && !wavecomplete1)
            {
                wavecomplete1 = true;
                wavecomplete0 = true;
            }
            if (!wavecomplete0)
            {
                wavecomplete0 = true;
            }
            timer = 0;
        }
    }
    private void SpawnEnemy()
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized * (spawnRadius + cameraMargin);
        Vector3 spawnPosition = new Vector3(randomPoint.x, randomPoint.y, 0f);
        Vector3 worldSpawnPosition = mainCamera.ViewportToWorldPoint(spawnPosition);

        if (!IsPositionWithinCamera(worldSpawnPosition))
        {
            Instantiate(enemyPrefab, worldSpawnPosition, Quaternion.identity);
            if (wavecomplete0)
            {
                Vector2 randomPoint1 = Random.insideUnitCircle.normalized * (spawnRadius + cameraMargin);
                Vector3 spawnPosition1 = new Vector3(randomPoint1.x, randomPoint1.y, 0f);
                Vector3 worldSpawnPosition1 = mainCamera.ViewportToWorldPoint(spawnPosition1);
                Instantiate(enemyPrefab1, worldSpawnPosition1, Quaternion.identity);
            }
            if (wavecomplete1)
            {
                Vector2 randomPoint2 = Random.insideUnitCircle.normalized * (spawnRadius + cameraMargin);
                Vector3 spawnPosition2 = new Vector3(randomPoint2.x, randomPoint2.y, 0f);
                Vector3 worldSpawnPosition2 = mainCamera.ViewportToWorldPoint(spawnPosition2);
                Instantiate(enemyPrefab2, worldSpawnPosition2, Quaternion.identity);
            }
            if (wavecomplete2)
            {
                Vector2 randomPoint3 = Random.insideUnitCircle.normalized * (spawnRadius + cameraMargin);
                Vector3 spawnPosition3 = new Vector3(randomPoint3.x, randomPoint3.y, 0f);
                Vector3 worldSpawnPosition3 = mainCamera.ViewportToWorldPoint(spawnPosition3);
                Instantiate(enemyPrefab3, worldSpawnPosition3, Quaternion.identity);
            }
        }
    }

    private bool IsPositionWithinCamera(Vector3 position)
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(position);
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
