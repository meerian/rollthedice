using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public int multiplier = 1;
    public bool multiplierPositive = true;
    public int time = 45;

    public bool canRoll = true;

    public bool gameEnd = false;

    public bool turboTime = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
}
