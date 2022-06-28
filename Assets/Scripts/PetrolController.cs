using UnityEngine;

public class PetrolController : MonoBehaviour
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
            CarController.numberOfPetrolCans += 1;
            //Debug.Log("CO2 : " + CarController.numberOfPetrolCans);
            Destroy(gameObject);
        }
    }
}
