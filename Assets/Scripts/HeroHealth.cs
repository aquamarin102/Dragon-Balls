using UnityEngine;

namespace Quest
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 10f;
        [SerializeField] private float _curHealth;
        private float _sliderValue;
        private void Awake()
        {
            _curHealth = _maxHealth;
        }
        
        private void Update()
        {
            _sliderValue = (_curHealth/_maxHealth);
        }
        
        public void Hit(float damage)
        {
            _curHealth -= damage;
            if (_curHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
        
        private void OnGUI()
        {
            _sliderValue = GUI.HorizontalSlider(new Rect(25, 25, 300, 60), _sliderValue, 0, 1);
        }
    }
}
