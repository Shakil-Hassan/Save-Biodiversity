using UnityEngine;

public class PetrolController : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>() != null)
        {
            CarController.numberOfPetrolCans += 1;
            Destroy(gameObject);
        }
    }
}
