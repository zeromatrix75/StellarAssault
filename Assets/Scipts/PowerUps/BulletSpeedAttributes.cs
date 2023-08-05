using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedAttributes : MonoBehaviour
{

    private Movement move;
    private SpriteRenderer sr;
    private float colorChangeDelay = 0.1f; // Delay between color changes in seconds
    private Vector3 direction;
    public float speed = 10.0f;
    public int steadinessConstant = 120;
    private int steadiness; 
    private float yDirection;
    public AudioSource playSound;
    //public AudioClip playClip;    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChangeObjectColor", colorChangeDelay, colorChangeDelay);
    }

    void Awake() 
    {
        move = GetComponent<Movement>();
         steadiness = steadinessConstant;    
    }

    void Update(){
        if(steadiness == 0)
        {
            yDirection = Random.Range(-1f, 1f);
            steadiness = steadinessConstant;
        }
        else
        {   
            steadiness--;
        }
         direction = new Vector3(-1f, yDirection, 0f);
         move.Move(direction, speed);
    }


    // Update is called once per frame
    void ChangeObjectColor()
    {
        sr.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        GameObject collidedObject = collision.gameObject;
    
        if (collidedObject.CompareTag("Player"))
        {
            Player player = collidedObject.GetComponent<Player>();
                if(playSound == null)
                    Debug.Log("audiosoure is null");
                Debug.Log("Success in audiosource.play");

                // Code for handling collision with the Player object
                if(GameManager.inputController.firingSpeed > .16f){
                    GameManager.inputController.firingSpeed-= 0.12f;
                    Debug.Log("Success Firing Speed: " + GameManager.inputController.firingSpeed);
                }

                //Keep sound effect from cutting off after destroying object
                playSound.transform.parent = null;
                playSound.Play();

                Destroy(playSound.gameObject, 2);
                Destroy(gameObject);
        }   
       
    }
}
