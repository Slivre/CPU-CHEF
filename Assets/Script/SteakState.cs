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

    public AudioClip FlopNoise;
    AudioSource audioSource;
    AudioSource SFXPlayer;

    public GameObject Smoke;
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        cpuTemp = FindObjectOfType<CPUTemp>();
        audioSource = GetComponent<AudioSource>();
        SFXPlayer = GameObject.Find("SFXPlayer").GetComponent<AudioSource>();
        Smoke.SetActive(false);
    }

    void Update()
    {
        if (isCooking && cpuTemp != null)
        {
            float temperature = cpuTemp.GetCurrentTemperature();

            float TempMod = (temperature - cpuTemp.MinTemp)* 0.05f;

            cookTime += Time.deltaTime * TempMod;

            
            cookPercent = cookTime / requiredTime;

            UpdateSteakSprite();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cpu")
        {
            isCooking = true;
            audioSource.Play();
            StartCoroutine(Fade(audioSource, 1, 1));
            Smoke.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "cpu")
        {
            isCooking = false;
            StartCoroutine(Fade(audioSource, 1, 0));
            Smoke.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Table")
        {
            SFXPlayer.clip = FlopNoise;
            SFXPlayer.Play();
        }

        if (collision.gameObject.tag == "KillZone")
        {
            Destroy(gameObject);
            GM.SpawnNewSteak();
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void UpdateSteakSprite()
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

    public bool CheckOut()
    {
        Debug.Log("Checkout");
        GM.SpawnNewSteak();
        Destroy(gameObject);
        if (currentCookState == GM.targetState)
        {
            GM.CompleteOrder(true);
            return true;
        }
        else if(currentCookState != GM.targetState)
        {
            GM.CompleteOrder(false);
            return false;
        }
        return false;
    }

    public IEnumerator Fade(AudioSource source, float dur, float targetVolume)
    {
        float time = 0f;
        float startVolume = source.volume;
        while(time < dur)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / dur);
            yield return null;
        }
    }
}