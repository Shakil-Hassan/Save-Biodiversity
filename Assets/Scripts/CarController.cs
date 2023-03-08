using DefaultNamespace;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("CarController")]
    [SerializeField] private float carForwardSpeed;
    [SerializeField] private float carMaxSpeed;
    [SerializeField] private Rigidbody rigidbodyCar;

    private static CarController instance;

    // Used For Road
    // desiredPath -> 0 : left 1 : middle 2 : right
    // pathDistance -> the distance between two paths
    private int desiredPath = 1;
    [SerializeField] private float pathDistance = 4;
    [SerializeField] private float smoothSpeedForTransition = 80;

    public static int numberOfBatteries;
    public static int numberOfPetrolCans;

    [SerializeField] private OxygenBarController oxygenBar;
    [SerializeField] private CarbonBarController carbonDioxideBar;

    [SerializeField] private LevelCompleteScreen levelCompleteScreen;
    [SerializeField] private GameOverScreen gameOverScreen;
    

    private void Start()
    {
        oxygenBar.OxygenSlider.minValue = 0;
        carbonDioxideBar.CarbonSlider.minValue = 0;
        numberOfBatteries = 0;
        numberOfPetrolCans = 0;
        oxygenBar.SetMinOxygen(numberOfBatteries);
        carbonDioxideBar.SetMinCarbon(numberOfPetrolCans);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredPath++;
            if (desiredPath == 3)
            {
                desiredPath = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredPath--;
            if (desiredPath == -1)
            {
                desiredPath = 0;
            }
        }
        
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredPath == 0)
        {
            targetPosition += Vector3.left * pathDistance;
        }
        else if (desiredPath == 2)
        {
            targetPosition += Vector3.right * pathDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeedForTransition);

        oxygenBar.SetOxygen(numberOfBatteries);
        carbonDioxideBar.SetCarbon(numberOfPetrolCans);
        LevelComplete();
        GameOver();
    }

    private void FixedUpdate()
    {
        rigidbodyCar.velocity = new Vector3(rigidbodyCar.velocity.x, rigidbodyCar.velocity.y, carForwardSpeed * Time.fixedDeltaTime);
    }

    public void LevelComplete()
    {
        if (numberOfBatteries >= oxygenBar.OxygenSlider.maxValue)
        {
            carForwardSpeed = 0;
            levelCompleteScreen.Setup();
        }
    }

    public void GameOver()
    {
        if (numberOfPetrolCans >= carbonDioxideBar.CarbonSlider.maxValue)
        {
            carForwardSpeed = 0;
            gameOverScreen.Setup();
        }
    }
}
