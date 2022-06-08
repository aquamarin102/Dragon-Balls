using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _boostSpeed;
        [SerializeField] private float _jumpForce = 200f;
        [SerializeField] private GameObject _viewCamera;
        
        private int _pickupCoin = 0;
        private int _scaleCoins;
        private Rigidbody _rigidbody;
        
        private float _deltaX, _deltaZ;

        [SerializeField] private Text _coinsText;
        private const string _horizontal = "Horizontal";
        private const string  _vertical = "Vertical";
        private const string _jump = "Jump";

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {

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

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.tag == "Coin")
            {
                _pickupCoin++;
                _coinsText.text = _pickupCoin.ToString();
                Destroy(other.gameObject);
            }

            if (_pickupCoin == 5)
            {
                Camera.main.GetComponent<UIManager>().Win();
            }
        }

        public void SetSpeedBoostOn (float speedMultiplier)
        {
            _boostSpeed = _speed;
            _speed *= speedMultiplier;
        }
        public void SetSpeedBoostOff ()
        {
            _speed = _boostSpeed;
        }
    }
}