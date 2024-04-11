using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBarriers : MonoBehaviour
{
    public float delay = 4f;
    public float initialDelay = 1f;
    float nextTime2 = 10f;
    float nextTime = 0;
    public float decreasePerDelay = 0.02f; // Zmieniłem nazwę zmiennej dla spójności
    public GameObject barrierPrefab;

    public Transform[] positionsTransform;

    

    void Start()
    {
        // Ustawienie początkowego opóźnienia dla pierwszego spawnu obiektu bariery
        nextTime = Time.time + initialDelay;
    }


    Vector3 randomizePosition(Transform[] positions)
    {
        if (positions.Length == 1)
        {
            return positions[0].position;
        }
        else
        {
            if (positions.Length == 0)
            {
                return Vector2.zero;
            }
            int randomInt = Random.Range(0, positions.Length);
            return positions[randomInt].position;
        }
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            GameObject instance = Instantiate(barrierPrefab, randomizePosition(positionsTransform), barrierPrefab.transform.rotation, gameObject.transform);
            Destroy(instance, 25f);
            delay -= decreasePerDelay;
            nextTime = Time.time + delay;
            if (Time.time >= nextTime2)
            {
                GameObject instance2 = Instantiate(barrierPrefab, randomizePosition(positionsTransform), barrierPrefab.transform.rotation, gameObject.transform);
                Destroy(instance2, 25f);
                nextTime2 = nextTime;
            }
        }
    }
}
