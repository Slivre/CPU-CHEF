using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppButton : MonoBehaviour
{
    public CPUTemp cpuTemp;
    public float TempModifier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseTemp()
    {
        float TempMod = TempModifier;
        Debug.Log($"TempMod: {TempMod}");
    }

    public void DecreaseTemp()
    {
        float TempMod = -TempModifier;
        Debug.Log($"TempMod: {TempMod}");
    }
}
