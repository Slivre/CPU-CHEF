using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HighScoreList", order = 1)]
public class SO_HighScoreList : ScriptableObject
{
    public Dictionary<string, int> PlayerHighscores;
}
