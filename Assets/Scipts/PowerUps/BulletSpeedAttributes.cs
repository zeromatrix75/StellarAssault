using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedAttributes : MonoBehaviour
{

    
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        sr.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f),Random.Range(0,1f));
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        GameObject collidedObject = collision.gameObject;
    
        if (collidedObject.CompareTag("Player"))
        {
            Player player = collidedObject.GetComponent<Player>();


                // Code for handling collision with the Player object
                if(GameManager.inputController.firingSpeed > .16f){
                    GameManager.inputController.firingSpeed-= 0.12f;
                    Debug.Log("Success Firing Speed: " + GameManager.inputController.firingSpeed);
                }

                Destroy(this.gameObject);
        }   
       
    }
}
