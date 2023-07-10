using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public AudioSource boomSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        

        if (player != null){
            player.health--;
            Debug.Log("Player health: " + player.health);

            if(player.health == 0){
                boomSound = GetComponent<AudioSource>();
                boomSound.Play();
                Destroy(player.gameObject);
                Invoke("LoadMainMenu", 1.5f);//Wait one second before using method LoadMainMenu()
            }
        }
    }

        void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
