using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScreenManager : MonoBehaviour
{
   private SceneManager sceneManager;
    public string playMoreURL;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MoreGame()
    {
        Application.OpenURL(playMoreURL);
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited Sucessfully");
        Application.Quit(0);
    }
}
