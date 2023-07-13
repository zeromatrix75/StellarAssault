using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public Player player;
    Text Text;


    void Awake(){
        Text = GetComponent<Text>();
    }

    void Update()
    {
        Text.text =   "Health: " + player.health.ToString() + "\n";
    }
}
