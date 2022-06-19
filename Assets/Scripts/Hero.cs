using System;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class Hero : MonoBehaviour, IUnit
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 200f;
        [SerializeField] private GameObject _viewCamera;
        [SerializeField] private float _maxHealth;
        [SerializeField] private Text _scorePoinText;
        
        private float _curHealth;
        private int _pickupCoin;
        private int _scaleCoins;
        private float _deltaX, _deltaZ;
        
        private Rigidbody _rigidbody;

        private const string _horizontal = "Horizontal";
        private const string  _vertical = "Vertical";
        private const string _jump = "Jump";

        public static Action WinDelegate;
        public static Action LoseDelegate;
        public static Action GetDamage;
        public static Action<float> OnHPChaged;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _curHealth = _maxHealth;
        }
        
        private void FixedUpdate()
        {
            //Move
            _deltaX = Input.GetAxis(_horizontal) * (_speed);
            _deltaZ = Input.GetAxis(_vertical) * (_speed);

            _rigidbody.AddTorque(Vector3.back * _deltaX);
            _rigidbody.AddTorque(Vector3.right * _deltaZ);
            if (Input.GetButtonDown(_jump)) 
            {
                _rigidbody.AddForce(Vector3.up*_jumpForce);
            }
            

            //camera
            if (_viewCamera != null) {
                Vector3 direction = (Vector3.up*2+Vector3.back)*2;
                RaycastHit hit;
                Debug.DrawLine(transform.position,transform.position+direction,Color.red);
                if(Physics.Linecast(transform.position,transform.position+direction,out hit)){
                    _viewCamera.transform.position = hit.point;
                }else{
                    _viewCamera.transform.position = transform.position+direction;
                }
                _viewCamera.transform.LookAt(transform.position);
            }
        }
        

        //Boost speed
        public void SetSpeedBoostOn (float speedMultiplier)
        {
            _speed *= speedMultiplier;
        }

        // Heal
        public void SetHealthAdjustment (float adjustmentAmount)
        {
            _curHealth += adjustmentAmount;
            if (_curHealth > 10)
            {
                _curHealth = 10;
            }
            OnHPChaged?.Invoke(_curHealth);
        }

        // Take damage
        public void Hit(float damage)
        {
            try
            {
                GetDamage?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            _curHealth-= damage;
            OnHPChaged?.Invoke(_curHealth);
            if (_curHealth <= 0)
            {
                Die();
            }
        }

        //Die
        private void Die()
        {
            gameObject.SetActive(false);
            
            try
            {
                LoseDelegate?.Invoke();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GetCoin(other.gameObject);
           
        }

        public void GetCoin(GameObject coin)
        {
            if (coin.tag == "Coin")
            {
                _pickupCoin++;
                _scorePoinText.text = _pickupCoin.ToString();
                Destroy(coin.gameObject);
            }

            if (_pickupCoin == 5)
            {
                WinDelegate?.Invoke();
            }
        
        }
        
    }
}