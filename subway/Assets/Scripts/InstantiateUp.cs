using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUpPrefabs : MonoBehaviour
{
    public float delay = 4f;
    float nextTime = 0;
    public float decreasePerDelay = 2*PlayerPrefs.GetFloat("GameSpeed", 0.01f);
    float nextTime2 = 10f;
    public GameObject upPrefab; // Prefab "up"

    public Transform[] positionsTransform;

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
            GameObject instance = Instantiate(upPrefab, randomizePosition(positionsTransform), upPrefab.transform.rotation, gameObject.transform);
            Destroy(instance, 25f);
            delay -= decreasePerDelay;
            nextTime = Time.time + delay;
            if (Time.time >= nextTime2)
            {
                GameObject instance2 = Instantiate(upPrefab, randomizePosition(positionsTransform), upPrefab.transform.rotation, gameObject.transform);
                Destroy(instance2, 25f);
                nextTime2 = nextTime;
            }
        }
    }
}
