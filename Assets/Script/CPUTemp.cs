using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUTemp : MonoBehaviour
{
    public float CPUTemperture = 50.0f;

    public float TargetTemperture;

    public float AccelerationSpeed;

    public float MaxTemp;
    public float MinTemp;

    // Start is called before the first frame update
    void Start()
    {
        TargetTemperture = CPUTemperture;
    }

    public float GetCurrentTemperature()
    {
        return CPUTemperture;
    }

    // Update is called once per frame
    void Update()
    {
        if (CPUTemperture > TargetTemperture)
        {
            CPUTemperture -= AccelerationSpeed * Time.deltaTime;
        }
        else if(CPUTemperture < TargetTemperture) 
        {
            CPUTemperture += AccelerationSpeed * Time.deltaTime;
        }

        TargetTemperture = Mathf.Clamp(TargetTemperture, MinTemp, 999f);
    }

    public void ModifiyTargetTemp(float ModValue)
    {
        TargetTemperture += ModValue;
    }
}
