using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class MainMenuManagerScript : MonoBehaviour
{

    //public AudioClip buttonSound;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private string sceneNameToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeMenuScene(string sceneName)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource != null && audioClip != null){
            audioSource.PlayOneShot(audioClip);
            //Prevent Sound from Cutting Off
            DontDestroyOnLoad(audioSource.gameObject);
        }
        else{
            Debug.Log("AudioSource is NULL");
        }

        sceneNameToLoad = sceneName;
        StartCoroutine(Waiting());
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        SceneManager.LoadScene(sceneNameToLoad);
    }


    
    public void QuitGame(){
        Application.Quit();
    }
    
}
