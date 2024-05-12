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
    bool PauseTimer = true;
    public float newOrderDelay;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("NewOrder",2f);
        cpuTemp = FindObjectOfType<CPUTemp>();
        SucessIcon.SetActive(false);
        FailIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cpuTemp.CPUTemperture >= cpuTemp.CrashTemperture)
        {
            Crash();
        }

        else if (cpuTemp.CPUTemperture <= cpuTemp.RestartTemperture)
        {
            Restart();
        }

        if (!PauseTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                CompleteOrder(false);
                PauseTimer = true;
            }
        }
    }

    public void SpawnNewSteak()
    {
        Instantiate(Steak, StakeSpawn.position, Quaternion.identity);
    }

    public void NewOrder()
    {
        SucessIcon.SetActive(false);
        FailIcon.SetActive(false);

        timer = orderTime;
        PauseTimer = false;
        targetState = (SteakState.SteakCookState)Random.Range(1, 4);
        orderPanel.NewOrder(targetState);
    }

    public void CompleteOrder(bool Sucess)
    {
        PauseTimer = true;
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
}
