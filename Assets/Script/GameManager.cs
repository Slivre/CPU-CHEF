using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public string PlayerName;
    public int Score;
    public int HighScore;
    public bool SteakInScene;

    SaveSystem saveSystem;

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

    public int GameWorldTime;
    public TMP_Text GameWorldTimeTxt;

    bool GameEnded;
    public GameObject EndScreen;
    public TMP_Text EndScreenScore;
    public TMP_Text EndScreenHighScore;


    // Start is called before the first frame update
    void Start()
    {
        EndScreen.SetActive(false);
        cpuTemp = FindObjectOfType<CPUTemp>();
        SucessIcon.SetActive(false);
        FailIcon.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    public void GameStart()
    {
        GameEnded = false;
        OrderClosed = true;

        cpuTemp.CPUTemperture = cpuTemp.MinTemp;
        cpuTemp.TargetTemperture = cpuTemp.MinTemp;
        foreach (AppButton closebutton in closeButtons)
        {
            closebutton.CloseApp();
        }

        Score = 0;
        orderPanel.BlankOrder();
        EndScreen.SetActive(false);
        GameWorldTime = 6;

        CancelInvoke("GameWorldTimeUpdate");
        Invoke("NewOrder", 2f);
        Invoke("GameWorldTimeUpdate", 20f);
    }

    public void GameWorldTimeUpdate()
    {
        GameWorldTime++;
        Invoke("GameWorldTimeUpdate", 20f);
    }

    public void GameEnd()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
        }

        GameEnded = true;
        EndScreen.SetActive(true);
        EndScreenScore.text = $"${Score}";
        EndScreenHighScore.text = $"Highest: ${HighScore}";
        saveSystem.newHighScore(PlayerName, Score);

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEnded)
        {
            GameWorldTimeTxt.text = $"{GameWorldTime}PM";
            if (GameWorldTime >= 12)
            {
                GameEnd();
            }

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
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
        Time.timeScale = Paused ? 0 : 1;
        PauseScreen.SetActive(Paused);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        targetState = (SteakState.SteakCookState)Random.Range(1, 5);
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
