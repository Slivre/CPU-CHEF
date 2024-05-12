using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashProgressBar : MonoBehaviour
{
    public float TempPercecntage;
    public CPUTemp cpuTemp;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        cpuTemp = FindObjectOfType<CPUTemp>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float safeTemp = cpuTemp.MaxTemp - cpuTemp.MinTemp;
        TempPercecntage = (cpuTemp.CPUTemperture -safeTemp) / safeTemp;

        slider.value = TempPercecntage;
    }
}
