using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    GameManager GM;
    public TMP_InputField PlayerName;

    public SO_HighScoreList scoreListObj;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void SetName()
    {
        if (!PlayerPrefs.HasKey(PlayerName.text))
        {
            PlayerPrefs.SetInt(PlayerName.text, 0);
        }
        GM.PlayerName = PlayerName.text;
    }

    public void newHighScore(string NewPlayerName, int NewHighScore)
    {
        int smallest = 99999;
        string smallestKey = null;
        foreach(string player in scoreListObj.PlayerHighscores.Keys)
        {
            if (scoreListObj.PlayerHighscores[player] < smallest)
            {
                smallest = scoreListObj.PlayerHighscores[player];
                smallestKey = player;
            }
        }

        if (NewHighScore > smallest)
        {
            scoreListObj.PlayerHighscores.Remove(smallestKey);
            scoreListObj.PlayerHighscores.Add(NewPlayerName, NewHighScore);
        }
    }

}
