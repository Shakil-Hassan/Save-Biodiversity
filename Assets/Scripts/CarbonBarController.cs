using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CarbonBarController : MonoBehaviour
    {
        public Slider CarbonSlider;
    
        public void SetMinCarbon(int carbon)
        {
            CarbonSlider.minValue = carbon;
            CarbonSlider.value = carbon;
        }

        public void SetCarbon(int carbon)
        {
            CarbonSlider.value = carbon;
        }
    }
}