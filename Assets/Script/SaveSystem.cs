using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    GameManager GM;
    public TMP_InputField PlayerName;

    public SO_HighScoreList scoreListObj;
    public TMP_Text playerNameTxt;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void SetName()
    {
        GM.PlayerName = PlayerName.text;
        playerNameTxt.text = PlayerName.text;
    }

    public void newHighScore(string NewPlayerName, int NewHighScore)
    {
        scoreListObj.highscores.Add(new Highscore(NewPlayerName, NewHighScore));
        

        int smallest = 99999;
        string smallestKey = null;
        foreach(string player in scoreListObj.PlayerHighscores.Keys)
        {
            Debug.Log($"{player}, {scoreListObj.PlayerHighscores[player]}");
            if (scoreListObj.PlayerHighscores[player] < smallest)
            {
                smallest = scoreListObj.PlayerHighscores[player];
                smallestKey = player;
            }
        }

        if (scoreListObj.PlayerHighscores.Count < 10)
        {
            TryAddNewHighScroe(NewPlayerName, NewHighScore);
        }
        else
        {
            if (NewHighScore > smallest)
            {
                if(TryAddNewHighScroe(NewPlayerName, NewHighScore))
                {
                    scoreListObj.PlayerHighscores.Remove(smallestKey);
                }          
            }
        }
    }

    public bool TryAddNewHighScroe(string PlayerName, int NewHighScore)
    {
        if (scoreListObj.PlayerHighscores.ContainsKey(PlayerName))
        {
            Debug.Log("Found Same Name");
            if (NewHighScore > scoreListObj.PlayerHighscores[PlayerName])
            {
                Debug.Log($"Refreshing to new Highscore: {NewHighScore}");
                scoreListObj.PlayerHighscores[PlayerName] = NewHighScore;
                Debug.Log($"New Highscore: {scoreListObj.PlayerHighscores[PlayerName]}");
                return false;
            }
            return false;
        }
        else
        {
            Debug.Log($"Adding new Highscore: {PlayerName} : {NewHighScore}");
            scoreListObj.PlayerHighscores.Add(PlayerName, NewHighScore);
            Debug.Log($"New Highscore: {scoreListObj.PlayerHighscores[PlayerName]}");
            return true;
        }
    }

}
