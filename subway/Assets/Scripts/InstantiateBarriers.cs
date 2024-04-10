using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBarriers : MonoBehaviour
{
    public float delay = 1f;
    float nextTime = 0;
    public float decreasePerDelay = 0.0001f; // Zmieniłem nazwę zmiennej dla spójności
    public GameObject barrierPrefab;

    public Transform[] positionsTransform;

    Vector3 RandomizePosition()
    {
        if (positionsTransform.Length == 1)
        {
            return positionsTransform[0].position;
        }
        else
        {
            if (positionsTransform.Length == 0)
            {
                return Vector2.zero;
            }
            int randomInt = Random.Range(0, positionsTransform.Length);
            return positionsTransform[randomInt].position;
        }
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            GameObject instance = Instantiate(barrierPrefab, RandomizePosition(), barrierPrefab.transform.rotation, gameObject.transform);
            Destroy(instance, 25f);
            delay -= decreasePerDelay;
            nextTime = Time.time + delay;
        }
    }
}
