using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings - 1));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}