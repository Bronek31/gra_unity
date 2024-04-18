using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private float startTime;
    private bool gameStopped = false;
    public GameObject gameOverobj;
    private int currentScore = 0;
    private int currentScoreMinutes = 0;
    private int currentScoreSeconds = 0;
    private int currentScoreMilliseconds = 0;
    private int bestScore = 0; 
    
    void Start()
    {
        startTime = Time.time;
        gameStopped = false;
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == "GameOverScreenPlay")
            {
                gameOverobj = obj;
                break;
            }    
        }
        // Odczytaj najlepszy wynik z pamięci urządzenia
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void OnGUI()
    {
        float elapsedTime = Time.time - startTime;
        // Aktualizuj bieżący wynik jako czas gry
        currentScoreMinutes = Mathf.FloorToInt(elapsedTime / 60);
        currentScoreSeconds = Mathf.FloorToInt(elapsedTime) % 60;
        currentScoreMilliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);
        currentScore = currentScoreMinutes * 60 * 1000 + currentScoreSeconds * 1000 + currentScoreMilliseconds;

        // Jeśli gra nie jest zatrzymana, obliczaj czas normalnie
        if (!gameStopped)
        {
            // Obliczamy minuty przez podzielenie przez 60
            int minutes = Mathf.FloorToInt(elapsedTime / 60);

            // Obliczamy sekundy przez odjęcie milisekund i pozostałe sekundy po odjęciu pełnych minut
            int seconds = Mathf.FloorToInt(elapsedTime) % 60;

            // Obliczamy milisekundy przez resztę z dzielenia przez 1000
            int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

            GUIStyle style = new GUIStyle(GUI.skin.label); // Tworzymy nowy styl oparty na domyślnym stylu etykiety
            style.fontSize = 40; // Ustawiamy rozmiar czcionki na 40
            style.normal.textColor = Color.yellow; // Ustawiamy kolor tekstu na żółty

            GUI.Label(new Rect(Screen.width - 200, 10, 300, 200), string.Format("{0:00}{1:00}{2:000}", minutes, seconds, milliseconds), style);
            style.fontSize = 20; // Ustawiamy rozmiar czcionki na 40
            style.normal.textColor = Color.green; // Ustawiamy kolor tekstu na żółty
            GUI.Label(new Rect(10,10, 300, 200), "Best Score: " + bestScore, style);
        }

        
    }

    // Metoda wywoływana po kolizji z pociągiem
    void OnCollisionEnter(Collision col)
    {
        if((col.gameObject.tag == "Train" || col.gameObject.tag == "barrier" || col.gameObject.tag == "up") && !gameStopped)
        {
            // Zatrzymaj grę i czas
            Time.timeScale = 0;
            gameStopped = true;
            gameOverobj.SetActive(true);

            // Sprawdź, czy uzyskano nowy najlepszy wynik
            if (currentScore > bestScore)
            {
                bestScore = currentScore+1;
                // Zapisz najlepszy wynik w pamięci urządzenia
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.Save();
            }
        }
    }

    // Metoda zwracająca bieżący wynik
    public int GetCurrentScore()
    {
        return currentScore;
    }
}
