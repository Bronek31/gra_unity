using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTrains : MonoBehaviour
{
    public float delay = 2f;
    float nextTime = 0;
    float nextTime2 = 20f; // Po 30 sekundach zaczyna się pojawiać w drugim spawnpoint
    public float decreaseperdelay = 0.01f;
    public GameObject trainPrefab;

    public Transform[] positionsTransform;
    
    void Start(){
        decreaseperdelay = PlayerPrefs.GetFloat("GameSpeed", 0.01f);
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
            GameObject instance = Instantiate(trainPrefab, randomizePosition(positionsTransform), trainPrefab.transform.rotation, gameObject.transform);
            Destroy(instance, 25f);
            delay -= decreaseperdelay;
            nextTime = Time.time + delay;
            if (Time.time >= nextTime2)
            {
                GameObject instance2 = Instantiate(trainPrefab, randomizePosition(positionsTransform), trainPrefab.transform.rotation, gameObject.transform);
                Destroy(instance2, 25f);
                nextTime2 = nextTime;
            }
        }

        
    }
}
