using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakCooking : MonoBehaviour
{
    float cookPercent;

    public SpriteRenderer steakRenderer; 
    public CPUTemp cpuTemp;
    private bool isCooking = false;

    public float cookTime = 0; 
    public float requiredTime = 10; 

    private Color rawColor = Color.red; 
    private Color cookedColor = Color.yellow; 
    private Color overcookedColor = Color.black; 

    void Update()
    {
        if (isCooking && cpuTemp != null)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cpu")
        {
            isCooking = true; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "cpu")
        {
            isCooking = false;
        }
    }

    public void CheckOut()
    {
        Debug.Log("Checkout");
    }
}