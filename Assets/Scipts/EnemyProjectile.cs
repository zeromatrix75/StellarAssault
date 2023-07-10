using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float spawnInterval = 0.4f; // Interval in seconds between each spawn
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
            int spawnLength = Random.Range(1, 5);//Determine how many projectiles to shoot in a row
            float spawnX = Random.Range(minX, maxX);
            float spawnY = mainCamera.transform.position.y + cameraHeight + 1.0f;
            for(int i = 0; i < spawnLength; i++){
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                SpawnProjectile(spawnPosition);
                spawnY+=.25f;
            }
            
            timer = 0f; // Reset the timer
        }
    }


    void SpawnProjectile(Vector2 spawnPosition)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Destroy(newProjectile, 4);//Destroys projectile after 2 seconds
    }


}