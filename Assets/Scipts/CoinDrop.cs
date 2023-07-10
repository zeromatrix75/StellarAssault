using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float spawnInterval = 1.0f; // Interval in seconds between each spawn
    private float timer = 0f;

    Camera mainCamera;
    float cameraHeight;
    float cameraWidth;
    float minX;
    float maxX;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;//Get Camera height to put projecile slightly above it
        cameraWidth = cameraHeight * mainCamera.aspect;
        minX = -4.0f;//mainCamera.transform.position.x - cameraWidth;
        maxX = 4.0f; //mainCamera.transform.position.x + cameraWidth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        //Checks to see if half second has passed by to instantiate projectile
        if (timer >= spawnInterval)
        {
            SpawnProjectile();
            
            timer = 0f; // Reset the timer
        }
    }


    void SpawnProjectile()
    {
        float spawnX = Random.Range(minX, maxX);
        float spawnY = mainCamera.transform.position.y + cameraHeight + 1.0f;
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Destroy(newProjectile, 4);//Destroys projectile after 4 seconds
    }


}

