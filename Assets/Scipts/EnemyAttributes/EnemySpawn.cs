using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnInterval; // Interval in seconds between each spawn
    public float spawnStartTime;
    public float spawnStopTime;
    public float totalTime;
    private float timer = 0f; 

    Camera mainCamera;
    float cameraHeight;
    float cameraWidth;
    public float minY;
    public float maxY;

    private bool enemy1ShouldSpawn = true;
    private bool enemy2ShouldSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;//Get Camera height to put projecile slightly above it
        cameraWidth = cameraHeight * mainCamera.aspect;
        //minY = -4.0f;//mainCamera.transform.position.x - cameraWidth;
        //maxY = 4.0f; //mainCamera.transform.position.x + cameraWidth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        //Checks to see if half second has passed by to instantiate projectile
        if (timer >= spawnInterval)
        {
            //int spawnLength = Random.Range(1, 5);//Determine how many projectiles to shoot in a row
            float spawnY = Random.Range(minY, maxY);
            float spawnX = mainCamera.transform.position.x + cameraWidth + 1.0f;
            //for(int i = 0; i < spawnLength; i++){
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                SpawnProjectile(spawnPosition);
                //spawnY+=.25f;
            //}
            
            timer = 0f; // Reset the timer
        }
    }


    void SpawnProjectile(Vector2 spawnPosition)
    {
        GameObject newProjectile = Instantiate(Enemy, spawnPosition, Quaternion.identity);
        Destroy(newProjectile, 10);//Destroys projectile after 10 seconds
    }


}