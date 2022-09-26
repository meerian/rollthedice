using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStart : MonoBehaviour
{
    public GameObject ui;
    public GameObject dice;
    public GameObject multiplier;
    public GameObject gamestart;
    public TextMeshProUGUI countdownText;

    private int countdown = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        AudioManager.Instance.Play("beep");
        yield return new WaitForSeconds(1);
        countdown--;
        countdownText.text = countdown.ToString();
        if (countdown == 0)
        {
            StartGame();
        }
        else
        {
            StartCoroutine("Countdown");
        }
    }

    private void StartGame()
    {
        AudioManager.Instance.Play("gameend");
        ui.SetActive(true);
        dice.SetActive(true);
        multiplier.SetActive(true);
        gamestart.SetActive(false);
    }
}
