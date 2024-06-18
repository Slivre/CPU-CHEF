using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HighScoreList", order = 1)]
public class SO_HighScoreList : ScriptableObject
{
    public Dictionary<string, int> PlayerHighscores = new Dictionary<string, int>();

    public List<Highscore> highscores = new List<Highscore>();


    [ContextMenu("Show data")]
    public void showData()
    {
        Debug.Log("ShowData");
        foreach(Highscore highscore in highscores)
        {
            Debug.Log(highscore.PlayerName + highscore.PlayerScore);
        }
    }
 }
