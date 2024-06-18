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

    public GameObject Instructions;
    public GameObject SkipButton;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();

        GlobalLight.color = Color.black;

        ScoreDisplayer.SetActive(false);
        Screen.SetActive(false);
        Instructions.SetActive(false);
        Spotlight.gameObject.SetActive(false);
        SkipButton.SetActive(false);
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
        GlobalLight.color = Color.white;
        ScoreDisplayer.SetActive(true);

        yield return new WaitForSeconds(2);
        Title.SetActive(false);
        Instructions.SetActive(true);
        SkipButton.SetActive(true);

        yield return new WaitForSeconds(17);
        Instructions.SetActive(false);
        GM.GameStart();

        Spotlight.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        BGM.Play();

        yield return new WaitForSeconds(1);
        GM.SpawnNewSteak();

        yield return null;
    }

    public void skip()
    {
        StopCoroutine(Cor_StartGame());
        GlobalLight.color = Color.white;
        ScoreDisplayer.SetActive(true);
        Title.SetActive(false);
        Instructions.SetActive(false);
        GM.GameStart();
        Spotlight.gameObject.SetActive(true);
        BGM.Play();
        GM.SpawnNewSteak();
    }
}
