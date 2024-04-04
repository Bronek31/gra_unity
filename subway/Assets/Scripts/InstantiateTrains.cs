using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTrains : MonoBehaviour
{
    public float delay = 2f;
    float nextTime = 0;
    public float decreaseperdelay = 0.0001f;
    public GameObject trainPrefab;

    public Transform[] positionsTransform;


    Vector3 randomizePosition()
    {
        if(positionsTransform.Length == 1)
        {
            return positionsTransform[0].position;
        }
        else
        {
            if(positionsTransform.Length == 0)
            {
                return Vector2.zero;
            }
            int randomInt = Random.Range(0,positionsTransform.Length);
            return positionsTransform[randomInt].position;
        }
    }

    private void Update()
    {
        if(Time.time >= nextTime)
        {
            
            GameObject instance = Instantiate(trainPrefab,randomizePosition(),trainPrefab.transform.rotation, gameObject.transform); 
            Destroy(instance,25f);
            delay -= decreaseperdelay;
            nextTime = Time.time + delay;
        }
    }
}
