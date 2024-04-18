using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    // Definiujesz zdarzenie jako UnityEvent
    public UnityEvent OnGameStart;

    void Update()
    {
        // Sprawdź, czy została naciśnięta spacja
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Jeśli tak, wywołaj zdarzenie rozpoczęcia gry
            OnGameStart.Invoke();
        }
    }
}
