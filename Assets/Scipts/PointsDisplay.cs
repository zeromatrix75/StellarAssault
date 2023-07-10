using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Player player;
    Text pointsText;

    void Awake(){
        pointsText = GetComponent<Text>();
    }

    void Start()
    {
        pointsText.text = "Score: 0";
    }

    void Update()
    {
        pointsText.text = "Score: " + player.points.ToString();
    }
}
