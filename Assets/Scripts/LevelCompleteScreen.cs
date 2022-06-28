using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScreen : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
