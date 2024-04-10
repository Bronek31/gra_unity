using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private float startTime;
    private bool gameStopped = false;

    void Start()
    {
        startTime = Time.time;
    }

    void OnGUI()
    {
        float elapsedTime = Time.time - startTime;

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
        }
    }

    // Metoda wywoływana po kolizji z pociągiem
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Train" || col.gameObject.tag == "barrier" )
        {
            // Zatrzymaj grę i czas
            Time.timeScale = 0;
            gameStopped = true;
        }
    }
}
