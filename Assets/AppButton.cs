using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppButton : MonoBehaviour
{
    public CPUTemp cpuTemp;
    public float TempModifier;

    public GameObject APP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenAPP()
    {
        if (!APP.activeInHierarchy)
        {
            float TempMod = TempModifier;
            cpuTemp.ModifiyTargetTemp(TempMod);
            APP.SetActive(true);
        }
    }

    public void CloseApp()
    {
        if (APP.activeInHierarchy)
        {
            float TempMod = -TempModifier;
            cpuTemp.ModifiyTargetTemp(TempMod);
            APP.SetActive(false);
        }
    }
}
