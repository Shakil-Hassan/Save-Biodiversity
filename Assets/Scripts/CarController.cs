using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("CarController")]
    public float carForwardSpeed;
    public float carMaxSpeed;
    public Rigidbody rigidbodyCar;

    
    /// <summary>
    /// Used For Road
    /// desiredPath -> 0 : left 1 : middle 2 : right
    /// pathDistance -> the distance between two paths
    /// </summary>
    private int desiredPath = 1;
    public float pathDistance = 4;
    public float smoothSpeedForTransition = 80;

    public static int numberOfBatteries;
    public static int numberOfPetrolCans;

    public ProgressBarController oxygenBar;
    public ProgressBarController CarbonDioxideBar;

    public LevelCompleteScreen levelCompleteScreen;
    public GameOverScreen gameOverScreen;


    public void LevelComplete()
    {
        if(numberOfBatteries >= oxygenBar.slider.maxValue)
        {
            carForwardSpeed = 0;
            levelCompleteScreen.Setup();
            //Debug.Log("Level Completed");
        }   
    }

    public void GameOver()
    {
        if (numberOfPetrolCans >= CarbonDioxideBar.slider.maxValue)
        {
            carForwardSpeed = 0;
            gameOverScreen.Setup();
            //Debug.Log("Level Failed");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        oxygenBar.slider.minValue = 0;
        CarbonDioxideBar.slider.minValue = 0;
        numberOfBatteries = 0;
        numberOfPetrolCans = 0;
        oxygenBar.SetMinOxygen(numberOfBatteries);
        CarbonDioxideBar.SetMinCarbon(numberOfPetrolCans);
    }

    // Update is called once per frame
    void Update()
    {
        
            //Gather the inputs on which path car should swipe
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

            //Calculate car Direction when swipe
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
        CarbonDioxideBar.SetCarbon(numberOfPetrolCans);
        LevelComplete();
        GameOver();

    }

    private void FixedUpdate()
    {
        rigidbodyCar.velocity = new Vector3(rigidbodyCar.velocity.x, rigidbodyCar.velocity.y, carForwardSpeed * Time.fixedDeltaTime); 
    }

    
}
