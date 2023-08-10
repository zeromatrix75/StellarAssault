using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static PlayerInputController inputController;
    public static bool stageCleared = false;
    public static bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stageCleared){
            GetComponent<Canvas>().enabled = true;
            stageCleared = false;
        }

        if(gameOver){
            GetComponent<Canvas>().enabled = true;
            gameOver = false;
        }

    }
}
