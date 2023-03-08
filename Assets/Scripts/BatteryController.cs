using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0f, 100f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>() != null)
        {
            CarController.numberOfBatteries += 1;
            Destroy(gameObject);
        }
    }
}