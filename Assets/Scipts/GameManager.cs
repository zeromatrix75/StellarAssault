using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static PlayerInputController inputController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Go back to Main Menu on 0 HP. TODO add game over screen
        if(player.health == 0){
            SceneManager.LoadScene("MainMenu");
        }
    }
}
