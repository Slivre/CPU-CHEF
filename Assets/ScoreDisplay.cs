using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateScoreDisplay();
    }

    void Update()
    {

        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
       scoreText.text = "$" + gameManager.Score;
    }
}