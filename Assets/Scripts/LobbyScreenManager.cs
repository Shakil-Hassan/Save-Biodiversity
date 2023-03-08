using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScreenManager : MonoBehaviour
{
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
        Application.Quit();
    }
}