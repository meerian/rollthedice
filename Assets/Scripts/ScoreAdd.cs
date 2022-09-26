using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAdd : MonoBehaviour
{

    public Animator anim;
    public TextMeshProUGUI score;

    public void AddScore(int val)
    {
        score.color = new Color32(148, 227, 68, 255);
        score.text = "+" + val;
        anim.SetTrigger("show");
    }

    public void ReduceScore(int val)
    {
        score.color = new Color32(255, 22, 12, 255);
        score.text = "-" + val;
        anim.SetTrigger("show");
    }
}
