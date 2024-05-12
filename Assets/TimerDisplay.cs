using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerDisplay : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {            
        timerText.text = $"Time Left: {gameManager.timer:F2}";
    }
}
