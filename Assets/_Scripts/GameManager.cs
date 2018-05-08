using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public void StartGame()
    {
        Debug.Log("Starting");
        SceneManager.LoadScene("MainGameScreen");
    }
    public void WinGame()
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("WinScreen");
    }
    public void LoseGame()
    {
        Debug.Log("You Lose!");
        SceneManager.LoadScene("LoseScreen");
    }

}
