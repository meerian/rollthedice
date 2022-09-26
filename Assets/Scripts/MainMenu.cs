using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject credits;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
    }

    private void Update()
    {
        if (credits.activeSelf && Input.GetMouseButtonDown(0))
        {
            ToggleCredits();
        }
    }
    public void StartGame()
    {
        AudioManager.Instance.Play("click");
        StartCoroutine(LoadLevel(1));
    }

    public void PlayMouseover()
    {
        AudioManager.Instance.Play("mouseover");
    }

    public void ToggleCredits()
    {
        AudioManager.Instance.Play("click");
        credits.SetActive(!credits.activeSelf);
    }

    public void ToggleMute()
    {
        AudioManager.Instance.Play("click");
        AudioManager.Instance.ToggleMute();
    }

    public void QuitGame()
    {
        AudioManager.Instance.Play("click");
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelindex)
    {
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(0.5f);

        SceneManager.LoadScene(levelindex);
    }
}
