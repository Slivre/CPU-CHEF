using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakCooking : MonoBehaviour
{
    GameManager GM;
    float cookPercent;

    public SpriteRenderer steakRenderer; 
    public CPUTemp cpuTemp;
    private bool isCooking = false;

    public float cookTime = 0; 
    public float requiredTime = 10;

    public Sprite rawSprite;
    public Sprite mediumRareSprite;
    public Sprite mediumSprite;
    public Sprite welldoneSprite;
    public Sprite overcookedSprite;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        cpuTemp = FindObjectOfType<CPUTemp>();
    }

    void Update()
    {
        if (isCooking && cpuTemp != null)
        {
            
            float temperature = cpuTemp.GetCurrentTemperature(); 

            
            cookTime += Time.deltaTime * temperature / 100;

            
            cookPercent = cookTime / requiredTime;
            UpdateSteakSprite(cookPercent);
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

    void UpdateSteakSprite(float cookPercent)
    {
        if (cookPercent < 0.25f)
        {
            steakRenderer.sprite = rawSprite;
        }
        else if (cookPercent < 0.5f)
        {
            steakRenderer.sprite = mediumRareSprite;
        }
        else if (cookPercent < 0.75f)
        {
            steakRenderer.sprite = mediumSprite;
        }
        else if (cookPercent < 1f)
        {
            steakRenderer.sprite = welldoneSprite;
        }
        else
        {
            steakRenderer.sprite = overcookedSprite;
        }
    }

    public void CheckOut()
    {
        Debug.Log("Checkout");
        GM.SpawnNewSteak();
        Destroy(gameObject);
    }
}