using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion0 : MonoBehaviour
{
    // Start is called before the first frame update


    void Awake()
    {

    }
    
    void Start()
    {
        Invoke("DestroyObject", .7f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
