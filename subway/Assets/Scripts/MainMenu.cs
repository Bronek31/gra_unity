using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsObj;
    
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void SettingsMenu(){
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == "SettingsPanel")
            {
                SettingsObj = obj;
                break;
            }    
        }
        SettingsObj.SetActive(true);
    }
}
