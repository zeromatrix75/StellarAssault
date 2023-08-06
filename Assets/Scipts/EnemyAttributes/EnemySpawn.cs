using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnInterval; // Interval in seconds between each spawn
    private float currentSpawnInterval;
    private float halfSpawnInterval;
    public float spawnStartTime;
    public float spawnStopTime;
    private float timer = 0f; 
    private float delta;
    private float halfDelta;
    private float currentDelta;

    Camera mainCamera;
    float cameraHeight;
    float cameraWidth;
    public float minY;
    public float maxY;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cameraHeight = mainCamera.orthographicSize;//Get Camera height to put projecile slightly above it
        cameraWidth = cameraHeight * mainCamera.aspect;
        
        delta = spawnStopTime - spawnStartTime;
        halfDelta = delta/2.0f;
        halfSpawnInterval = spawnInterval * 2.0f;
        //minY = -4.0f;//mainCamera.transform.position.x - cameraWidth;
        //maxY = 4.0f; //mainCamera.transform.position.x + cameraWidth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        //Spawn only if between spawn start and stop time of scene
        if(spawnStartTime <= Time.timeSinceLevelLoad && Time.timeSinceLevelLoad < spawnStopTime){
        
        currentDelta = Time.timeSinceLevelLoad - spawnStartTime;

        if(currentDelta >= halfDelta && currentDelta <= (halfDelta*2.0f) ){
            currentSpawnInterval = spawnInterval;
            Debug.Log("Enter full Interval");

        }
        else if(currentDelta < halfDelta){
            currentSpawnInterval = halfSpawnInterval + 1.0f;
        }    
        else {
            currentSpawnInterval = halfSpawnInterval;
            Debug.Log("Entered half Interval");   
        }
        
        //Checks to see if half second has passed by to instantiate projectile
            if (timer >= currentSpawnInterval)
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
    }


    void SpawnProjectile(Vector2 spawnPosition)
    {
        GameObject newProjectile = Instantiate(Enemy, spawnPosition, Quaternion.identity);
        Destroy(newProjectile, 10);//Destroys projectile after 10 seconds
    }


}