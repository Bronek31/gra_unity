using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed; // Zmieniamy kierunek na przeciwny (do tyłu), aby przeszkody poruszały się w stronę gracza
    }

    private void Update()
    {
        // Możesz dodać dodatkowe funkcje aktualizacji tutaj, jeśli są potrzebne dla przeszkód
    }
}
