using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private int gameSceneInt;

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneInt);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
