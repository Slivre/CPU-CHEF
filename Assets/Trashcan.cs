using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public Sprite OpenLid;
    public Sprite CloseLid;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Steak")
        {
            GetComponent<SpriteRenderer>().sprite = CloseLid;
            GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Steak")
        {
            GetComponent<SpriteRenderer>().sprite = OpenLid;
            GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
}
