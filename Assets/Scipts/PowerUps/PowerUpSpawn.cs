using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject healthup;
    public GameObject speedup;
    public GameObject powerup;
    
    public float spawnInterval; // Interval in seconds between each spawn
    private float timer = 0f; 

    Camera mainCamera;
    float cameraHeight;
    float cameraWidth;
    public float minY;
    public float maxY;

    // Add a list to store the spawn methods
    private List<System.Action<Vector2>> spawnMethods = new List<System.Action<Vector2>>();



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;//Get Camera height to put projecile slightly above it
        cameraWidth = cameraHeight * mainCamera.aspect;
        
        spawnMethods.Add(SpawnHealthUp);
        spawnMethods.Add(SpawnSpeedUp);
        spawnMethods.Add(SpawnBombUp);
        spawnMethods.Add(SpawnBulletUp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        //Checks to see if half second has passed by to instantiate projectile
        if (timer >= spawnInterval)
        {
            float spawnY = Random.Range(minY, maxY);
            float spawnX = mainCamera.transform.position.x + cameraWidth + 1.0f;



            // Randomly select a spawn method from the list
            System.Action<Vector2> selectedSpawnMethod = spawnMethods[Random.Range(0, spawnMethods.Count)];

            // Call the selected spawn method with the spawn position
            selectedSpawnMethod(new Vector2(spawnX, spawnY));    

            
            timer = 0f; // Reset the timer
        }
    }


    void SpawnHealthUp(Vector2 spawnPosition)
    {
        GameObject powerspawn = Instantiate(healthup, spawnPosition, Quaternion.identity);
        Destroy(powerspawn, 5);
    }

    void SpawnSpeedUp(Vector2 spawnPosition)
    {
        GameObject powerspawn = Instantiate(speedup, spawnPosition, Quaternion.identity);
        Destroy(powerspawn, 5);
    }

    void SpawnBombUp(Vector2 spawnPosition)
    {
        GameObject powerspawn = Instantiate(healthup, spawnPosition, Quaternion.identity);
        Destroy(powerspawn, 5);
    }

    void SpawnBulletUp(Vector2 spawnPosition)
    {
        GameObject powerspawn = Instantiate(powerup, spawnPosition, Quaternion.identity);
        Destroy(powerspawn, 5);
    }


}
