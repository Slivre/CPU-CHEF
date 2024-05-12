using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{
    public Light2D GlobalLight;
    public Light2D Spotlight;
    public GameObject Screen;

    public GameObject Title;

    public AudioSource BGM;
    GameManager GM;
    public GameObject ScoreDisplayer;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();

        GlobalLight.color = Color.black;
        ScoreDisplayer.SetActive(false);
        Screen.SetActive(false);
        Spotlight.gameObject.SetActive(false);
        BGM.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartPressed()
    {
        StartCoroutine(Cor_StartGame());
    }

    public IEnumerator Cor_StartGame()
    {
        Screen.SetActive(true);
        GetComponent<Image>().color = Color.black;
        GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(2);

        GM.GameStart();
        GlobalLight.color = Color.white;
        Spotlight.gameObject.SetActive(true);
        ScoreDisplayer.SetActive(true);

        yield return new WaitForSeconds(2);
        Title.SetActive(false);
        BGM.Play();

        yield return new WaitForSeconds(1);
        GM.SpawnNewSteak();

        yield return null;
    }
}
