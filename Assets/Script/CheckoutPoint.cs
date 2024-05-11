using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.tag);
        if (collision.tag == "wellDone")
        {
            GameManager GM = FindObjectOfType<GameManager>();
            GM.AddScore(10);

        }

        SteakState steak = collision.GetComponent<SteakState>();
        if (steak != null)
        {
            steak.CheckOut();
        }

    }
}
