using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    
    public AudioSource audioSource;

    void Awake(){
        //flip box to diamond
        transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    void Start(){
         
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();//Get collided Player Object from 
        audioSource = other.GetComponent<AudioSource>();//Get Audio Source from Player object collided
        
        //add points and play sound
        if (player != null){
            audioSource.Play();
            player.points++;
            Destroy(this.gameObject);
        }
        
    }

}
