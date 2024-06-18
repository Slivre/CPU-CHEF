using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore
{
    public string PlayerName;
    public int PlayerScore;

    public Highscore(string playerName, int score)
    {
        this.PlayerName = playerName;
        this.PlayerScore = score;
    }
}
