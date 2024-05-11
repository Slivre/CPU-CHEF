using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutPoint : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SteakState steak = collision.GetComponent<SteakState>();
        if (steak != null)
        {
            steak.CheckOut();
            GM.NewOrder();
        }
    }
}
