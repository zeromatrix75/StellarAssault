using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    Movement move;
    Player player;

    public PlayerProjectileAction projectileAction;
    public Transform positionOffset;

    private bool isFiring = false; // Flag to track if the space button is being held down
    private bool canFire = true; // Flag to track if the player can fire a projectile
    public float firingSpeed = .5f;//fastest should only be .15f otherwise will mess with rigidbody
    public int projectileCount = 1; //Amount of projectiles shot at one time. Max of 3




    void Awake()
    {
        move = GetComponent<Movement>();
        player = GetComponent<Player>();
        GameManager.inputController = this;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            move.Move(new Vector3(1.0f, 0f, 0f), player.speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move.Move(new Vector3(-1.0f, 0f, 0f), player.speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move.Move(new Vector3(0f, -1.0f, 0f), player.speed);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            move.Move(new Vector3(0f, 1.0f, 0f), player.speed);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            isFiring = true; // Set the firing flag to true when spacebar is pressed
            StartCoroutine(FireProjectiles()); // Start the coroutine
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isFiring = false; // Set the firing flag to false when spacebar is released
        }
    }

    IEnumerator FireProjectiles()
    {
        canFire = false; // Disable firing until coroutine completes
        while (isFiring)
        {
            if(projectileCount == 1){
                Debug.Log("projectile count = 1");
                Instantiate(projectileAction, positionOffset.position, positionOffset.rotation);
            }
            else if(projectileCount == 2){

                Debug.Log("projectile count = 2");
                Vector3 offsetPosition1 = positionOffset.position + new Vector3(0f, .25f, 0f);
                Instantiate(projectileAction, offsetPosition1, positionOffset.rotation);
                Vector3 offsetPosition2 = positionOffset.position + new Vector3(0f, -.25f, 0f);
                Instantiate(projectileAction, offsetPosition2, positionOffset.rotation);
            }
            else{
                Instantiate(projectileAction, positionOffset.position, positionOffset.rotation);
                Vector3 offsetPosition1 = positionOffset.position + new Vector3(-.25f, .5f, 0f);
                Instantiate(projectileAction, offsetPosition1, positionOffset.rotation);
                Vector3 offsetPosition2 = positionOffset.position + new Vector3(-.25f, -.5f, 0f);
                Instantiate(projectileAction, offsetPosition2, positionOffset.rotation);
            }

            yield return new WaitForSeconds(firingSpeed); // Wait for the next frame
        }
        canFire = true; // Enable firing after coroutine completes
    }
}

