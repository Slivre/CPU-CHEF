using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteakPlate : MonoBehaviour
{
    public AudioClip sucessClip;
    public AudioClip FailClip;

    AudioSource audioSource;

    public void OrderSucess(bool sucess)
    {
        if (sucess)
        {
            audioSource.clip = sucessClip;
        }
        else
        {
            audioSource.clip = FailClip;
        }
        audioSource.Play();
    }

    public void InitializeSteak(Sprite sprite, bool sucess)
    {
        audioSource = GetComponent<AudioSource>();
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;
        OrderSucess(sucess);
    }

    public void DestroyPlate()
    {
        Destroy(gameObject,2f);
    }
}
