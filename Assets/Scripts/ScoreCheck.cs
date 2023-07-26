using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    public static int lastScore;
    public static int highScore = 0;
    public TextMeshProUGUI highText;
    public TextMeshProUGUI lastText;
    public TextMeshProUGUI infomationText;


    void Awake()
    {
        lastText.text = lastScore.ToString();
        highText.text = highScore.ToString();
    }

    private void Record()
    {
        if (lastScore > highScore)
        {
            highScore = lastScore;
            lastText.text = lastScore.ToString();
            highText.text = highScore.ToString();
            infomationText.gameObject.SetActive(true);
            
        }
        else
        {
            lastText.text = lastScore.ToString();
            highText.text = highScore.ToString();
        }
    }

}
