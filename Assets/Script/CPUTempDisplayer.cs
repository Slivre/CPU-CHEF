using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CPUTempDisplayer : MonoBehaviour
{
    TMP_Text text;
    public CPUTemp cpuTemp;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text =  $"CPUTemp: {Mathf.RoundToInt(cpuTemp.CPUTemperture)}";

        if (cpuTemp.CPUTemperture >= 125)
        {
            text.color = Color.red;
        }
        else if(cpuTemp.CPUTemperture >= 100 && cpuTemp.CPUTemperture < 125)
        {
            text.color = Color.yellow;
        }
        else
        {
            text.color = Color.white;
        }
    }
}
