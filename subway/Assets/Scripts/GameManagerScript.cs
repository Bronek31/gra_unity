using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUI;
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
    public void GameOver(){
        gameOverUI.SetActive(true);
    }
    
}
