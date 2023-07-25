using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TargetSelect : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI infoText;
    public static int scoreCount;
    public static int totalCount = 3;
    public float fadeTime = 2f;


    void Awake()
    {
        
        scoreText.text = scoreCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ScoreUp()
    {
        if (totalCount > 0)
        {
            infoText.text = "correct!";
            PadeIn();
            Invoke("PadeOut", 2);
            scoreCount += 10;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            totalCount -= 1;
            totalText.text = totalCount.ToString();
            scoreText.text = scoreCount.ToString();
        }
        else
        {
            infoText.text = "Finsh!";
            PadeIn();
            Invoke("PadeOut", 2);
            SceneManager.LoadScene("finish");
            scoreText.text = scoreCount.ToString();
        }
    }

    public void ScoreDown()
    {
        infoText.text = "not correct!";
        scoreCount -= 1;
        scoreText.text = scoreCount.ToString();
        PadeIn();
        Invoke("PadeOut", 2);

    }

    public void PadeIn()
    {
        infoText.gameObject.SetActive(true);
    }

    public void PadeOut()
    {
        infoText.gameObject.SetActive(false);
    }
}
