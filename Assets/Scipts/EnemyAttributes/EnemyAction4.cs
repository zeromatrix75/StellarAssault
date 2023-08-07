using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction4 : MonoBehaviour
{
    /*Enemy movement Variables and delay patterns*/
    public float initialSpeed = 4.0f;
    public float increasedSpeed = 8.0f;
    public float moveDuration = 1.5f; // Time to move before stopping
    public float speedIncreaseDelay = 2.5f; // Delay before increasing speed

    public float rotationStep = -20.0f; // Rotates while firing

    private Movement move;
    private float currentSpeed;
    private bool shouldMove = true;

    /*Projectile Variables*/
    public EnemyProjectileAction projectile;
    public Transform positionOffset;
    public float firingSpeed = .3f;

    // Start is called before the first frame update
    void Awake()
    {
        move = GetComponent<Movement>();
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldMove)
        {
            move.Move(new Vector3(-1.0f, 0f, 0f), currentSpeed);
        }
    }

    void Start()
    {
        StartCoroutine(MoveThenStopThenIncreaseSpeed());
    }

    IEnumerator MoveThenStopThenIncreaseSpeed()
    {
        // Phase 1: Move for a certain duration
        yield return new WaitForSeconds(moveDuration);

        // Phase 2: Stop moving
        shouldMove = false;
        StartCoroutine(FireProjectiles());
        // Phase 3: Wait for the speed increase delay
        yield return new WaitForSeconds(speedIncreaseDelay);

        // Phase 4: Increase speed and start moving again
        currentSpeed = increasedSpeed;
        shouldMove = true;
    }



    IEnumerator FireProjectiles()
    {

                for(int i = 0; i < 8; i++){

                    transform.Rotate(Vector3.forward, rotationStep);

                    Instantiate(projectile, positionOffset.position, positionOffset.rotation);
                    yield return new WaitForSeconds(firingSpeed); // Wait for the next frame
                }
    }
}


