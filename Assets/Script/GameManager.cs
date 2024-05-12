using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public bool SteakInScene;

    public Transform StakeSpawn;
    public GameObject Steak;
    public OrderPanel orderPanel;

    public SteakState.SteakCookState targetState;
    public CPUTemp cpuTemp;

    public GameObject CrashScreen;
    public GameObject FailIcon;
    public GameObject SucessIcon;

    public AppButton[] closeButtons;

    public float orderTime = 10.0f;
    public float timer;
    public bool OrderClosed = true;
    public float newOrderDelay;

    public float TempIncreaseInterval = 1f;
    float CurrentInterval;

    public AudioClip newOrderSFX;
    AudioSource audioSource;

    public bool Paused;
    public GameObject PauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        cpuTemp = FindObjectOfType<CPUTemp>();
        SucessIcon.SetActive(false);
        FailIcon.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void GameStart()
    {
        Invoke("NewOrder", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (cpuTemp.CPUTemperture >= cpuTemp.MaxTemp)
        {
            Crash();
        }

        else if (cpuTemp.CPUTemperture <= cpuTemp.MinTemp)
        {
            Restart();
        }

        if (!OrderClosed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                CompleteOrder(false);
                OrderClosed = true;
            }
        }

        CurrentInterval += Time.deltaTime;
        if (CurrentInterval >= TempIncreaseInterval)
        {
            ChangeTemperture();
            CurrentInterval = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
        Time.timeScale = Paused ? 0 : 1;
        PauseScreen.SetActive(Paused);
    }

    public void pauseGame()
    {
        Paused = !Paused;
    }

    public void ChangeTemperture()
    {
        int ClosedApp = 0;
        foreach(AppButton app in closeButtons)
        {
            if (app.gameObject.activeInHierarchy)
            {
                cpuTemp.TargetTemperture++;
            }
            else
            {
                ClosedApp++;
            }
        }

        if (ClosedApp >= closeButtons.Length)
        {
            cpuTemp.TargetTemperture -= 3;
        }
    }

    public void SpawnNewSteak()
    {
        Instantiate(Steak, StakeSpawn.position, Quaternion.identity);
    }

    public void NewOrder()
    {
        audioSource.clip = newOrderSFX;
        audioSource.Play();

        SucessIcon.SetActive(false);
        FailIcon.SetActive(false);

        timer = orderTime;
        OrderClosed = false;
        targetState = (SteakState.SteakCookState)Random.Range(1, 4);
        orderPanel.NewOrder(targetState);
    }

    public void CompleteOrder(bool Sucess)
    {
        OrderClosed = true;
        Invoke("NewOrder", newOrderDelay);
        if (Sucess)
        {
            Score += 10;
            SucessIcon.SetActive(true);
            SucessIcon.GetComponent<Animator>().Play("SucessSpawn");
        }
        else
        {
            Score -= 5;
            FailIcon.SetActive(true);
            FailIcon.GetComponent<Animator>().Play("FailSpawn");
        }
    }

    public void AddScore(int points)
    {
        Score += points; 
    }

    public void Crash()
    {
        CrashScreen.SetActive(true);
        foreach(AppButton closebutton in closeButtons)
        {
            closebutton.CloseApp();
        }
    }

    public void Restart()
    {
        CrashScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
