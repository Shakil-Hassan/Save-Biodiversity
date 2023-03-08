using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class OxygenBarController : MonoBehaviour
    {
        public Slider OxygenSlider;
        
        public void SetMinOxygen(int oxygen)
        {
            OxygenSlider.minValue = oxygen;
            OxygenSlider.value = oxygen;
        }

        public void SetOxygen(int oxygen)
        {
            OxygenSlider.value = oxygen;
        }
        
    }
}