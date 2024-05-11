using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakCooking : MonoBehaviour
{
    float cookPercent;

    public SpriteRenderer steakRenderer; 
    public CPUTemp cpuTemp; 

    public float cookTime = 0; 
    public float requiredTime = 10; 

    private Color rawColor = Color.red; 
    private Color cookedColor = Color.yellow; 
    private Color overcookedColor = Color.black; 

    void Update()
    {
        if (cpuTemp != null)
        {
            
            float temperature = cpuTemp.GetCurrentTemperature(); 

            
            cookTime += Time.deltaTime * temperature / 100;

            
            cookPercent = cookTime / requiredTime;
            if (cookPercent < 1)
            {
                steakRenderer.color = Color.Lerp(rawColor, cookedColor, cookPercent);
            }
            else
            {
                steakRenderer.color = Color.Lerp(cookedColor, overcookedColor, cookPercent - 1);
            }
        }
    }

    public void CheckOut()
    {
        Debug.Log("Checkout");
    }
}