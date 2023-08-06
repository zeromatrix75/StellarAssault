using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileAction : MonoBehaviour
{

    
    
    public float speed = 2;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * Time.fixedDeltaTime * speed;

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