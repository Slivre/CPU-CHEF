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
    public AppButton[] closeButtons;

    // Start is called before the first frame update
    void Start()
    {
        NewOrder();
        cpuTemp = FindObjectOfType<CPUTemp>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cpuTemp.CPUTemperture >= cpuTemp.CrashTemperture)
        {
            Crash();
        }

        else if(cpuTemp.CPUTemperture <= cpuTemp.RestartTemperture)
        {
            Restart();
        }
    }

    public void SpawnNewSteak()
    {
        Instantiate(Steak, StakeSpawn.position, Quaternion.identity);
    }

    public void NewOrder()
    {
        targetState = (SteakState.SteakCookState)Random.Range(1, 4);
        orderPanel.NewOrder(targetState);
    }

    public void AddScore(int points)
    {
        Score += points; 
        Debug.Log("Score: " + Score);
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
