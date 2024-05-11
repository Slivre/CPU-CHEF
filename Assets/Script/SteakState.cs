using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakState : MonoBehaviour
{
    public enum SteakCookState { Raw, Rare, MediumRare, Medium, WellDone,Overcooked}
    public SteakCookState currentCookState = SteakCookState.Raw;

    public Sprite[] CookStateSprite;

    GameManager GM;
    float cookPercent;

    public SpriteRenderer steakRenderer; 
    public CPUTemp cpuTemp;
    private bool isCooking = false;

    public float cookTime = 0; 
    public float requiredTime = 10;

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
        if (cookPercent < 0.2f)
        {
            currentCookState = SteakCookState.Raw;
        }
        else if (cookPercent < 0.4f)
        {
            currentCookState = SteakCookState.Rare;
        }
        else if (cookPercent < 0.6f)
        {
            currentCookState = SteakCookState.MediumRare;
        }
        else if (cookPercent < 0.8f)
        {
            currentCookState = SteakCookState.Medium;
        }
        else if (cookPercent < 1f)
        {
            currentCookState = SteakCookState.WellDone;
        }
        else
        {
            currentCookState = SteakCookState.Overcooked;
        }
        steakRenderer.sprite = CookStateSprite[(int)currentCookState];
    }

    public void CheckOut()
    {
        Debug.Log("Checkout");
        if (currentCookState == GM.targetState)
        {
            GM.AddScore(10);
        }

        GM.SpawnNewSteak();
        GM.NewOrder();
        Destroy(gameObject);
    }
}