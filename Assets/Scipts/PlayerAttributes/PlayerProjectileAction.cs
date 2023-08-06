using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAction : MonoBehaviour
{

    Rigidbody2D rb;
    
    public float speed = 12;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.right * Time.fixedDeltaTime * speed;
        rb.MovePosition(transform.position + (new Vector3(1.0f, 0f, 0f) * speed * Time.fixedDeltaTime));

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Destroy(gameObject);
    }
}
