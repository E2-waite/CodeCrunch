using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public bool SetHighScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            return true;
        }

        return false;
    }

    public int GetCurrentHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0); ;
    }


}
