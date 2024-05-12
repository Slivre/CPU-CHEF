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

    public float orderTime = 10.0f;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        NewOrder();
        timer = orderTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            FailOrder();
            NewOrder();
            timer = orderTime; 
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

    public void CompleteOrder()
    {
        AddScore(10);
        ResetTimer();
        NewOrder();
    }

    private void ResetTimer()
    {
        timer = orderTime;
    }

    private void FailOrder()
    {
        Score -= 5;
        ResetTimer();
        NewOrder();

    }

    public void AddScore(int points)
    {
        Score += points; 
    }
}
