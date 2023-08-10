using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Actions : MonoBehaviour
{
    /*Enemy movement Variables and delay patterns*/
    public float initialSpeed = 4.0f;
    public float increasedSpeed = 12.0f;
    public float moveDuration = 1.5f; // Time to move before stopping
    public float speedIncreaseDelay = 2.5f; // Delay before increasing speed
    public float moveCount = 0;
    public float rotationStep = -15.0f; // Rotates while firing

    private Movement move;
    private float currentSpeed;
    //private bool shouldFire = true;
    private bool firstMove = true;
    private bool shouldMoveForward = false;
    private bool shouldMoveBackward = false;
    private bool shouldMoveUp = false;
    private bool shouldMoveDown = false;


    /*Projectile Variables*/
    public EnemyProjectileAction projectile;
    public EnemyProjectileAction projectile2;
    public EnemyProjectileAction projectile3;
    public Transform positionOffset1;
    public Transform positionOffset2;
    public Transform positionOffset3;
    private Transform currentPositionOffset1;
    private Transform currentPositionOffset2;
    public float firingSpeed = .3f;

    // Start is called before the first frame update
    void Awake()
    {
        move = GetComponent<Movement>();
        currentSpeed = initialSpeed;
        currentPositionOffset1 = positionOffset1;
        currentPositionOffset2 = positionOffset2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (firstMove)
        {
            move.Move(new Vector3(-1.0f, 0f, 0f), currentSpeed);
        }
        else
        {
            currentSpeed = increasedSpeed;
            if (shouldMoveForward){
                move.Move(new Vector3(-1.0f, 0f, 0f), currentSpeed);
            }
            else if(shouldMoveBackward){
                            move.Move(new Vector3(1.0f, 0f, 0f), currentSpeed);
            }
            else if(shouldMoveUp){
                move.Move(new Vector3(0.0f, 1.0f, 0f), currentSpeed);
            }
            else if(shouldMoveDown){
                move.Move(new Vector3(0.0f, -1.0f, 0f), currentSpeed);
            }


        }
    }

    void Start()
    {
        StartCoroutine(EnemyActions());
    }

    IEnumerator EnemyActions()
    {
        // Phase 1: Move for a certain duration
        yield return new WaitForSeconds(moveDuration);
        firstMove = false;

        int randomPhase= Random.Range(0,3);
        // Phase 2: Stop moving
        while (gameObject != null){
            if(randomPhase == 0){
                StartCoroutine(FireProjectiles1());
                yield return new WaitForSeconds(moveDuration);
                StartCoroutine(QuickBurst());
            }
            else{
                StartCoroutine(FireProjectiles1());
                yield return new WaitForSeconds(moveDuration);
                StartCoroutine(FireProjectiles1());
                yield return new WaitForSeconds(moveDuration);
                StartCoroutine(QuickBurst());
            }

            StartCoroutine(FireProjectiles2());
            yield return new WaitForSeconds(moveDuration * 2);

            if(Random.Range(0,2) == 0){ 
                StartCoroutine(UpDown());
                yield return new WaitForSeconds(moveDuration/1.4f);
                StartCoroutine(DownUp());
            }
            else{ 
                StartCoroutine(DownUp());
                yield return new WaitForSeconds(moveDuration/1.4f);
                StartCoroutine(UpDown());
            }
        }

        Debug.Log("Boss object became null");
    }



    IEnumerator FireProjectiles1()
    {

        for(int i = 0; i < 5; i++){

            currentPositionOffset1.Rotate(Vector3.forward, rotationStep);
            currentPositionOffset2.Rotate(-Vector3.forward, rotationStep);
    

            Instantiate(projectile, currentPositionOffset1.position, currentPositionOffset1.rotation);
            Instantiate(projectile, currentPositionOffset2.position, currentPositionOffset2.rotation);
            yield return new WaitForSeconds(firingSpeed); // Wait for the next frame
        }
        for(int i = 0; i < 5; i++){

            currentPositionOffset1.Rotate(-Vector3.forward, rotationStep);
            currentPositionOffset2.Rotate(Vector3.forward, rotationStep);
    

            Instantiate(projectile, currentPositionOffset1.position, currentPositionOffset1.rotation);
            Instantiate(projectile, currentPositionOffset2.position, currentPositionOffset2.rotation);
            yield return new WaitForSeconds(firingSpeed); // Wait for the next frame
        }

        currentPositionOffset1 = positionOffset1;
        currentPositionOffset2 = positionOffset2;
    }

        IEnumerator FireProjectiles2()
    {   
        int randomIndex = Random.Range(0, 2);

        if (Random.Range(0, 2) == 0)
        {
            for(int i = 0; i < 30; i++){
            Instantiate(projectile2, positionOffset3.position, positionOffset3.rotation);
            yield return new WaitForSeconds(firingSpeed * .75f); // Wait for the next frame
        }
        }
        else
        {
            for(int i = 0; i < 15; i++){
            Instantiate(projectile3, positionOffset3.position, positionOffset3.rotation);
            yield return new WaitForSeconds(firingSpeed * 1.2f); // Wait for the next frame
        }
        }


    }


    IEnumerator QuickBurst()
    {
        float tempMoveDuration;
        if(Random.Range(0,2) == 0)
            tempMoveDuration = moveDuration * 1.3f;
        else
            tempMoveDuration = moveDuration;
            
        shouldMoveForward = true;
        yield return new WaitForSeconds(tempMoveDuration);
        shouldMoveForward = false;
        shouldMoveBackward = true;
        yield return new WaitForSeconds(tempMoveDuration);
        shouldMoveBackward = false;
    }

    IEnumerator UpDown()
    {
        shouldMoveUp = true;
        yield return new WaitForSeconds(moveDuration/3);
        shouldMoveUp = false;

        shouldMoveDown = true;
        yield return new WaitForSeconds(moveDuration/3);
        shouldMoveDown = false;
    }

    IEnumerator DownUp()
    {
        shouldMoveDown = true;
        yield return new WaitForSeconds(moveDuration/3);
        shouldMoveDown = false;
        
        shouldMoveUp = true;
        yield return new WaitForSeconds(moveDuration/3);
        shouldMoveUp = false;
    }

}


