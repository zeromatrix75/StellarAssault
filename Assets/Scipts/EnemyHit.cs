using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public AudioSource boomSound;
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        

        if (player != null){
            player.health--;
            Debug.Log("Player health: " + player.health);

            if(player.health == 0){
                boomSound = GetComponent<AudioSource>();
                boomSound.Play();
                Destroy(this.gameObject);
                //Destroy(player.gameObject);
                //Invoke("LoadMainMenu", 1.5f);//Wait one second before using method LoadMainMenu()
            }
        }
    }
*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Player player = other.GetComponent<Player>();
        
        GameObject collidedObject = collision.gameObject;
    
        if (collidedObject.CompareTag("Player"))
        {
            Player player = collidedObject.GetComponent<Player>();
            if (player != null)
            {
                // Code for handling collision with the Player object
                player.health--;
                Debug.Log("Success: " + player.health);
            }
        }
        /*
                if (player != null){
                player.health--;
                Debug.Log("Player health: " + player.health);

                if(player.health == 0){
                    boomSound = GetComponent<AudioSource>();
                    boomSound.Play();
                    Destroy(this.gameObject);
                    //Destroy(player.gameObject);
                    //Invoke("LoadMainMenu", 1.5f);//Wait one second before using method LoadMainMenu()
                }
        }
        }
        else*/
        
                boomSound = GetComponent<AudioSource>();
                boomSound.Play();
                Destroy(this.gameObject);
        
        
        //if (player != null){
            //player.health--;
            //Debug.Log("Player health: " + player.health);

            //if(player.health == 0){
               // boomSound = GetComponent<AudioSource>();
               // boomSound.Play();
               // Destroy(this.gameObject);
                //Invoke("LoadMainMenu", 1.5f);//Wait one second before using method LoadMainMenu()
            //}
        //}
    }

        /*void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }*/
}
