using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public Slider slider;
    
    private static ProgressBarController instance;
    public static ProgressBarController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void SetMinOxygen(int oxygen)
    {
        slider.minValue = oxygen;
        slider.value = oxygen;
    }

    public void SetOxygen(int oxygen)
    {
        slider.value = oxygen;
    }
    public void SetMinCarbon(int carbon)
    {
        slider.minValue = carbon;
        slider.value = carbon;
    }

    public void SetCarbon(int carbon)
    {
        slider.value = carbon;
    }
}
