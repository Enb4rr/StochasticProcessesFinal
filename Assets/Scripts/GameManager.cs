using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Events Stuff

    public delegate void GameEvents();
    public GameEvents onEnd, reset;

    public void OnResetButton()
    {
        reset?.Invoke();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
