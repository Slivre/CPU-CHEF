using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUColorChange : MonoBehaviour
{
    CPUTemp cpuTemp;
    SpriteRenderer sr;

    public Color OverheatColor;

    private void Start()
    {
        cpuTemp = FindObjectOfType<CPUTemp>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float safeTemp = cpuTemp.MaxTemp - cpuTemp.MinTemp;
        float TempPercecntage = (cpuTemp.CPUTemperture - cpuTemp.MinTemp) / safeTemp;

        sr.color = Color.Lerp(Color.white, OverheatColor, TempPercecntage);
    }
}
