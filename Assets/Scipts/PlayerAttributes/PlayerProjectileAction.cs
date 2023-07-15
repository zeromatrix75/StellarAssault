using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAction : MonoBehaviour
{

    
    
    public float speed = 12;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.fixedDeltaTime * speed;

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
    }
}
