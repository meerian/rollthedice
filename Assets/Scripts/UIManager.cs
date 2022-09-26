using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    public TextMeshProUGUI multiplier;
    public TextMeshProUGUI turbotime;
    public TextMeshProUGUI question;
    public GameObject scoreadd;
    public GameObject timeadd;
    public GameObject turboText;
    public GameObject gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        time.text = GameManager.Instance.time.ToString();
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameManager.Instance.score.ToString();
        multiplier.text = "x" + GameManager.Instance.multiplier;
    }

    public void ToggleMultipliercolor()
    {
        if (GameManager.Instance.multiplierPositive)
        {
            multiplier.color = new Color32(148, 227, 68, 120);
            if (turboText.activeSelf)
            {
                turbotime.color = new Color32(148, 227, 68, 120);
            }
        }
        else
        {
            multiplier.color = new Color32(255, 22, 12, 120);
            if (turboText.activeSelf)
            {
                turbotime.color = new Color32(255, 22, 12, 120);
            }
        }
    }

    public void SetQuestion(int num)
    {
        switch (num)
        {
            case 1:
                question.text = "Higher?";
                return;
            case 2:
                question.text = "Lower?";
                return;
            case 3:
                question.text = "Less than 3?";
                return;
            case 4:
                question.text = "More than 4?";
                return;
            case 5:
                question.text = "Less than 5?";
                return;
            case 6:
                question.text = "More than 2?";
                return;
            case 7:
                question.text = "Equal?";
                return;
        }
    }

    public void AddScore(int val)
    {
        scoreadd.GetComponent<ScoreAdd>().AddScore(val);
    }

    public void AddTime(int val)
    {
        timeadd.GetComponent<ScoreAdd>().AddScore(val);
    }

    public void ReduceScore(int val)
    {
        scoreadd.GetComponent<ScoreAdd>().ReduceScore(val);
    }

    public void ReduceTime(int val)
    {
        timeadd.GetComponent<ScoreAdd>().ReduceScore(val);
    }

    public void ShowGameend()
    {
        gameEnd.SetActive(true);
        Time.timeScale = 1;
        AudioManager.Instance.ChangePitch("gamemusic", 0.9f);
    }

    public void PlayMouseover()
    {
        AudioManager.Instance.Play("mouseover");
    }

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        GameManager.Instance.time--;
        time.text = GameManager.Instance.time.ToString();
        if (GameManager.Instance.time <= 10)
        {
            if (!GameManager.Instance.turboTime)
            {
                turboText.SetActive(true);
                if (!GameManager.Instance.multiplierPositive)
                {
                    turbotime.color = new Color32(255, 22, 12, 120);
                }
                time.color = new Color32(255, 22, 12, 255);
                Time.timeScale = 2f;
                AudioManager.Instance.ChangePitch("gamemusic", 1.2f);
                GameManager.Instance.turboTime = true;
            }
            AudioManager.Instance.Play("beep");
        }
        if (GameManager.Instance.time == 0)
        {
            GameManager.Instance.gameEnd = true;
            ShowGameend();
        }
        else
        {
            StartCoroutine("Timer");
        }
    }
}
