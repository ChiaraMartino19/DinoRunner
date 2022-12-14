using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSounds : MonoBehaviour
{
    public float timeSounds;
    void Start()
    {
        Destroy(gameObject, timeSounds);
    }

    
    void Update()
    {
        
    }
}
