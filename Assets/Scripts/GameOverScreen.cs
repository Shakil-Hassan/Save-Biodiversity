using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private string activeSceneName;

    private void Awake()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    ///  SceneManager.LoadSceneAsync instead of SceneManager.LoadScene
    ///  to potentially reduce hiccups or freezes during scene transitions.
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadSceneAsync(activeSceneName);
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
    }
}