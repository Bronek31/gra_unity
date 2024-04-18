using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public int bestScore;
    private TimeCounter timeCounter;
    private float GameSpeed = 0.01f;
    private float slider_speed_conv;
    void Start()
    {
        GameSpeed = GetGameSpeedValue();
        // Odczytaj najlepszy wynik z pamięci urządzenia
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        // Znajdź obiekt zawierający skrypt TimeCounter
        timeCounter = FindObjectOfType<TimeCounter>();
    }

    public void MainMenu()
    {
        // Zapisz najlepszy wynik w pamięci urządzenia przed załadowaniem sceny MainMenu
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void restart()
    {
        // Załaduj ponownie scenę SampleScene
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);

        // Sprawdź, czy aktualny wynik jest lepszy niż najlepszy wynik
        if (timeCounter != null)
        {
            int currentScore = timeCounter.GetCurrentScore();
            if (currentScore > bestScore)
            {
                // Jeśli tak, zaktualizuj najlepszy wynik
                bestScore = currentScore;
                // Zapisz najlepszy wynik w pamięci urządzenia
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
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
