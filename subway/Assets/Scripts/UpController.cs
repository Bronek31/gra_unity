using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * speed; // Zmiana kierunku na "up"
    }

    private void Update()
    {
        // Tu możesz dodać kod, jeśli jest potrzebny
    }
}
