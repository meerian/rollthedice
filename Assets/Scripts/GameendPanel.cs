using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameendPanel : MonoBehaviour
{
    public TextMeshProUGUI score;
    public Animator transitionAnim;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("gameend");
        score.text = GameManager.Instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        AudioManager.Instance.Play("click");
        StartCoroutine(LoadLevel(1));
    }

    public void Home()
    {
        AudioManager.Instance.Play("click");
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelindex)
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(levelindex);
    }
}
