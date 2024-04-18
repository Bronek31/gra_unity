using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text bestScoreText;

    void Start()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        PlayerPrefs.Save();
        // Odczytaj najlepszy wynik z pamięci urządzenia
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        // Wyświetl najlepszy wynik na ekranie menu głównego
        bestScoreText.text = "Best Score: " + bestScore;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
