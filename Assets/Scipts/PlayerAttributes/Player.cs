using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float power = 1.0f;
    public float speed = 3.0f;
    public float points = 0;

    Rigidbody2D rb;

    //Awake is called before all other Start calls
    void Awake() {

        //set position of plane
        rb = GetComponent<Rigidbody2D>();
        GameManager.player = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(3.0f,0,0) * Time.deltaTime;
    }

   // public void RandomizeColor(){
   //     sr.color = new Color(Random.Rane(0f,1f), Random.Range(0f,1f),Random.Range(0,1f));
   // }

    //public void LauncProjectile(){
    //    GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
    //    newProjectile.GetComponent<Projectile>().LaunchProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
   // }

    //public void LaunchProjectile2(){
     //   GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        
    //    newProjectile.GetComponent()<Projectile>.LaunchProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
 
    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        
            health--;
            Debug.Log("Player health: " + health);

            if(health == 0){
               // boomSound = GetComponent<AudioSource>();
                //boomSound.Play();
                Destroy(this.gameObject);
                //Invoke("LoadMainMenu", 1.5f);//Wait one second before using method LoadMainMenu()
            }
    }
}