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
    public GameObject me;
    public static int scoreCount;
    public static int totalCount = 5;
    public float fadeTime = 2f;


    void Awake()
    {
        
        scoreText.text = scoreCount.ToString();
        totalText.text = totalCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ScoreUp()
    {
        if (totalCount > 1)
        {
            infoText.text = "correct!";
            PadeIn();
            scoreCount += 10;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            totalCount -= 1;
            Destroy(me);
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
