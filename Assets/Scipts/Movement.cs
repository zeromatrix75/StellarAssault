using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 direction, float speed){
        //transform.position += direction * speed * Time.deltaTime; //Crude form, has bounce back effect against other ridbodies
        rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));//note change from deltaTime to fixedDelta to solve slower speed issue(due to physics of rigidBody2D physics(only 50 updates per second cause its expensive)
    }
}
