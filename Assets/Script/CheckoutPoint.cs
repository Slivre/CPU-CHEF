using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutPoint : MonoBehaviour
{
    public GameObject SteakPlate;
    public Transform steakSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        SteakState steak = collision.GetComponent<SteakState>();
        if (steak != null && collision.isTrigger!=true)
        {
            steak.CheckOut();
            GameObject NewSteakPlate = Instantiate(SteakPlate, Vector3.zero,Quaternion.identity);
            NewSteakPlate.GetComponent<SteakPlate>().InitializeSteak(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
        }
    }
}
