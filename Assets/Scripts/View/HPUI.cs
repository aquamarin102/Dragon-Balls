using UnityEngine;
using UnityEngine.UI;

    public class HPUI : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _image;

        private const float _highHP = 7.5f;
        private const float _lowHP = 2.5f;
        
        private void Awake()
        {
            Subscribe();
            _image.color = Color.green;
        }

        private void Subscribe()
        {
            Hero.OnHPChaged += OnHPChanged;
        }

        private void OnHPChanged(float hp, float maxHP)
        {
            _slider.maxValue = maxHP;
            _slider.value = hp;
            if (hp > _highHP)
            {
                _image.color = Color.green;
            }
            if(hp < _highHP)
            {
                _image.color = Color.yellow;
            }
            if(hp < _lowHP)
            {
                _image.color = Color.red;
            }
        }

        private void OnDestroy()
        {
            Hero.OnHPChaged -= OnHPChanged;
        }
    }
