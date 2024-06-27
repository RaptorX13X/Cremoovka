using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private int gameSceneInt;
    [SerializeField] private Image whiteFlash;

    public void StartGame()
    {
        whiteFlash.DOFade(1f, 2f).OnComplete(() =>
        {
            SceneManager.LoadScene("GameplayScene");
        });
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
