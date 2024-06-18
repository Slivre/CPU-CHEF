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
    public GameObject UsernameEnter;
    public GameObject Loading;

    Coroutine RunningCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        UsernameEnter.SetActive(true);
        GlobalLight.color = Color.black;
        Title.SetActive(true);
        ScoreDisplayer.SetActive(false);
        Screen.SetActive(true);
        Instructions.SetActive(false);
        Spotlight.gameObject.SetActive(false);
        SkipButton.SetActive(false);
        BGM.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnterPressed()
    {
        RunningCoroutine = StartCoroutine(Cor_StartGame());
        UsernameEnter.SetActive(false);
        Loading.SetActive(true);
    }

    public IEnumerator Cor_StartGame()
    {
        GetComponent<Image>().color = Color.black;
        GlobalLight.color = Color.white;
        ScoreDisplayer.SetActive(true);

        yield return new WaitForSeconds(3);

        Loading.SetActive(false);
        Instructions.SetActive(true);
        SkipButton.SetActive(true);
        Title.SetActive(false);

        yield return new WaitForSeconds(17);
        Instructions.SetActive(false);
        GM.GameStart();
        SkipButton.SetActive(false);
        Debug.Log("BAM");

        Spotlight.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        BGM.Play();

        yield return new WaitForSeconds(1);
        GM.SpawnNewSteak();

        yield return null;
    }

    public void skip()
    {
        SkipButton.SetActive(false);
        StopCoroutine(RunningCoroutine);

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
