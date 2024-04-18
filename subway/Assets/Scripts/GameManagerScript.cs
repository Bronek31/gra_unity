using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{   
    
    private float GameSpeed = 0.01f;
    private float slider_speed_conv;
    void Start(){
        GameSpeed = GetGameSpeedValue();
    }
    public void MainMenu(){
        // gameStopped = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void restart(){
        // gameStopped = false;
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void set_slider_speed(float slider_value){
        slider_speed_conv = slider_value/100;
    }
    public void set_game_speed(){
        GameSpeed = slider_speed_conv;
        Debug.Log(GameSpeed);
        PlayerPrefs.SetFloat("GameSpeed", GameSpeed);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
    public float GetGameSpeedValue(){
        return PlayerPrefs.GetFloat("GameSpeed", 0.01f);
    }

}
