using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakBasket : MonoBehaviour
{
    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!GM.SteakInScene)
        {
            GiveNewSteak();
        }
    }

    public void GiveNewSteak()
    {
        
    }
}
