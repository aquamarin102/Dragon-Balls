using UnityEngine;
using UnityEngine.UI;


namespace Quest
{
    public class HPUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _image;
        
        private void Awake()
        {
            Subscribe();
            _slider.maxValue = 10;
            _slider.value = 10;
            _image.color = Color.green;
        }

        private void Subscribe()
        {
            Hero.OnHPChaged += OnHPChanged;
        }

        private void OnHPChanged(float hp)
        {
            _slider.value = hp;
            if (hp > 7.5)
            {
                _image.color = Color.green;
            }
            if(hp < 7.5)
            {
                _image.color = Color.yellow;
            }
            if(hp < 2.5)
            {
                _image.color = Color.red;
            }
        }

        private void OnDestroy()
        {
            Hero.OnHPChaged -= OnHPChanged;
        }
    }
}