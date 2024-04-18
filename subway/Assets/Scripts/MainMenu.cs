using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsObj;

    void Start()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.Save();
        // Odczytaj najlepszy wynik z pamięci urządzenia
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }
    
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
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
