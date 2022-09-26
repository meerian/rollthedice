using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public SpriteRenderer sr;
    public int cur;
    public Animator anim;

    public Sprite no5;

    private int curQuestion;

    // Start is called before the first frame update
    void Start()
    {
        int roll = UnityEngine.Random.Range(0, 6);
        curQuestion = roll;
        UIManager.Instance.SetQuestion(roll);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Roll(bool val)
    {
        if (GameManager.Instance.canRoll && !GameManager.Instance.gameEnd)
        {
            AudioManager.Instance.Play("click");
            AudioManager.Instance.Play("shake");
            int prev = cur;
            cur = UnityEngine.Random.Range(1, 7);
            anim.SetInteger("rollvalue", cur);
            anim.SetTrigger("roll");
            StartCoroutine(RevealResults(CheckAnswer(prev, val)));
            GameManager.Instance.canRoll = false;
        }
    }

    IEnumerator RevealResults(bool val)
    {
        yield return new WaitForSeconds(0.75f);
        AudioManager.Instance.Stop("shake");
        if (!GameManager.Instance.gameEnd)
        {
            if (val)
            {
                Correct();
            }
            else
            {
                Wrong();
            }
            int roll = UnityEngine.Random.Range(1, 8);
            curQuestion = roll;
            UIManager.Instance.SetQuestion(roll);
            GameManager.Instance.canRoll = true;
        }
    }

    private bool CheckAnswer(int prev, bool ans)
    {
        switch (curQuestion)
        {
            case 1:
                return (cur - prev > 0) == ans;
            case 2:
                return (cur - prev < 0) == ans;
            case 3:
                return (cur < 3) == ans;
            case 4:
                return (cur > 4) == ans;
            case 5:
                return (cur < 5) == ans;
            case 6:
                return (cur > 2) == ans;
            case 7:
                return (cur == prev) == ans;
            default:
                return false;
        }
    }

    private void Correct()
    {
        AudioManager.Instance.Play("correct");
        if (GameManager.Instance.multiplierPositive)
        {
            GameManager.Instance.multiplier++;
        }
        else
        {
            GameManager.Instance.multiplierPositive = true;
            GameManager.Instance.multiplier = 1;
            UIManager.Instance.ToggleMultipliercolor();
        }
        GameManager.Instance.score += 100 * GameManager.Instance.multiplier;
        UIManager.Instance.AddScore(100 * GameManager.Instance.multiplier);
        if (GameManager.Instance.time > 10)
        {
            GameManager.Instance.time ++;
            UIManager.Instance.AddTime(1);
            float temp = GameManager.Instance.multiplier - 1;
            Time.timeScale = 1 + 0.1f * temp;
            AudioManager.Instance.ChangePitch("gamemusic", 0.9f + 0.05f * temp);
        }
    }

    private void Wrong()
    {
        AudioManager.Instance.Play("wrong");
        CameraController.Instance.ShakeCamera(50f, 0.2f);
        if (GameManager.Instance.multiplierPositive)
        {
            GameManager.Instance.multiplierPositive = false;
            GameManager.Instance.multiplier = 1;
            UIManager.Instance.ToggleMultipliercolor();
        }
        else
        {
            GameManager.Instance.multiplier++;
        }
        GameManager.Instance.score = Math.Max(GameManager.Instance.score - 50 * GameManager.Instance.multiplier, 0);
        UIManager.Instance.ReduceScore(50 * GameManager.Instance.multiplier);
        if (GameManager.Instance.time > 10)
        {
            GameManager.Instance.time--;
            UIManager.Instance.ReduceTime(1);
            float temp = GameManager.Instance.multiplier - 1;
            Time.timeScale = 1 + 0.1f * temp;
            AudioManager.Instance.ChangePitch("gamemusic", 0.9f + 0.05f * temp);
        }
    }
}
