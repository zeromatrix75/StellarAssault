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
            isFiring = true; // Set the firing flag to true when space is pressed
            StartCoroutine(FireProjectiles()); // Start the coroutine
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isFiring = false; // Set the firing flag to false when space is released
        }
    }

    IEnumerator FireProjectiles()
    {
        canFire = false; // Disable firing until coroutine completes
        while (isFiring)
        {
            Instantiate(projectileAction, positionOffset.position, positionOffset.rotation);
            yield return new WaitForSeconds(firingSpeed); // Wait for the next frame
        }
        canFire = true; // Enable firing after coroutine completes
    }
}

