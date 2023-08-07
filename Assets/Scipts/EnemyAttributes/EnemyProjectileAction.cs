using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileAction : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 movementDirection;
    
    public float speed = 12;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= transform.right * Time.fixedDeltaTime * speed;
        rb.MovePosition(transform.position + ( -transform.right * speed * Time.fixedDeltaTime));//new Vector3(-1.0f, 0f, 0f)

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        GameObject collidedObject = collisionInfo.gameObject;

        if (collidedObject.CompareTag("Player")){
                GameManager.player.health--;
                Destroy(gameObject);
        }
        else if(collidedObject.CompareTag("Projectile1")){
            //Do Not Destroy
        }
        else{
            Destroy(gameObject);
        }
    }
}