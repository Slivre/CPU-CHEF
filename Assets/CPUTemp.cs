using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUTemp : MonoBehaviour
{
    public float CPUTemperture = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float GetCurrentTemperature()
    {
        return CPUTemperture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
