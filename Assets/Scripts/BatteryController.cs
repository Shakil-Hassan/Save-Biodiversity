using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>() != null)
        {
            CarController.numberOfBatteries += 1;
            //Debug.Log("Oxygen : " + CarController.numberOfBatteries);
            Destroy(gameObject);
        }
    }
}
