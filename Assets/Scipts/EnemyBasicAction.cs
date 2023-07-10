using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAction : MonoBehaviour
{
    public float initialSpeed = 4.0f;
    public float increasedSpeed = 8.0f;
    public float speedIncreaseDelay = 1.0f;

    private Movement move;
    private float currentSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        move = GetComponent<Movement>();
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.Move(new Vector3(-1.0f, 0f, 0f), currentSpeed);
    }

    void Start()
    {
        StartCoroutine(IncreaseSpeedAfterDelay());
    }

    IEnumerator IncreaseSpeedAfterDelay()
    {
        yield return new WaitForSeconds(speedIncreaseDelay);
        currentSpeed = increasedSpeed;
    }
}
