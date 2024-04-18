using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public int bestScore;
    private TimeCounter timeCounter;

    void Start()
    {
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

        // Załaduj scenę MainMenu
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
}
