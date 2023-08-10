using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{

    public Dropdown dropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;

    void Start(){


        bool firstTimeSetup = false;
        if(PlayerPrefs.GetInt("first time resolution") == 0){
            PlayerPrefs.SetInt("first time resolution",1);
            PlayerPrefs.SetInt("fullscreen",1);
            firstTimeSetup = true;
        }

        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++){
            string resName = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            dropdown.options.Add(new Dropdown.OptionData(resName));

            if(firstTimeSetup){
                if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                    dropdown.value = i;
                }
                PlayerPrefs.SetInt("resolution selection", dropdown.value);
            }
        }

            dropdown.value = PlayerPrefs.GetInt("resolution selection");
            fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreen") == 1;
    }


    public void SetResolution(){
        Resolution selectedResolution = resolutions[dropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullscreenToggle.isOn);
        PlayerPrefs.SetInt("resolution selection", dropdown.value);
        
        if(fullscreenToggle.isOn){
            PlayerPrefs.SetInt("fullscreen",1);
        }
        else{
            PlayerPrefs.SetInt("fullscreen",0);
        }
    }
    


}
