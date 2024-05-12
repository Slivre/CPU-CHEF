using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakPlate : MonoBehaviour
{
    public void InitializeSteak(Sprite sprite)
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void DestroyPlate()
    {
        Destroy(gameObject,2f);
    }
}
