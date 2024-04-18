using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pref_Script : MonoBehaviour
{


void Start()
    {
        // Ensure that this GameObject persists across scene changes
        DontDestroyOnLoad(gameObject);
    }
}
