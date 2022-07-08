using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

    public class Hero : MonoBehaviour, IUnit
    {
        [SerializeField, Range(1f, 20f), Tooltip("Hero speed")] private float _speed = 5f;
        [SerializeField, Range(100f, 400f), Tooltip("Jump force")] private float _jumpForce = 200f;
        [SerializeField] private float _maxHealth;
        [SerializeField, Range(1f, 5f)] private int _coinForWin = 5;
        [SerializeField] private GameObject _viewCamera;
        [SerializeField] private Text _scorePoinText;
        [SerializeField]private GameObject _gameObject;
        
        private float _curHealth;
        private float _deltaX, _deltaZ;
        private int _pickupCoin;
        private int _scaleCoins;
        private int _numberWins;

        private Rigidbody _rigidbody;

        private const string _horizontal = "Horizontal";
        private const string  _vertical = "Vertical";
        private const string _jump = "Jump";
        private const string _coinTag = "Coin";
        
        public static Action WinDelegate;
        public static Action LoseDelegate;
        public static Action GetDamage;
        public static Action<float, float> OnHPChaged;
        
        private SerializableXMLData<SaveData> _serializableXMLData = new SerializableXMLData<SaveData>();
        private SaveData _saveData = new SaveData() { Name = "Bonus", Position = new Vector3(0,0,0), NumberOfWins = 0};

        private void Start()
        {
            _saveData.Position = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y,
                _gameObject.transform.position.z);
            var path = Path.Combine(Application.streamingAssetsPath, "SerializableXMLSave.xml");
            _serializableXMLData.Save(_saveData, path);
            var save = _serializableXMLData.Load(path);
            Debug.Log(save);
            
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
            if (_curHealth > _maxHealth)
            {
                _curHealth = _maxHealth;
            }
            OnHPChaged?.Invoke(_curHealth, _maxHealth);
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
            OnHPChaged?.Invoke(_curHealth, _maxHealth);
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
            if (coin.tag == _coinTag)
            {
                _pickupCoin++;
                _scorePoinText.text = _pickupCoin.ToString();
                Destroy(coin.gameObject);
            }

            if (_pickupCoin == _coinForWin)
            {
                _numberWins++;
                _saveData.NumberOfWins = _numberWins;
                _saveData.Position = new Vector3(_gameObject.transform.position.x, _gameObject.transform.position.y,
                    _gameObject.transform.position.z);
                var path = Path.Combine(Application.streamingAssetsPath, "SerializableXMLSave.xml");
                _serializableXMLData.Save(_saveData, path);
                var save = _serializableXMLData.Load(path);
                Debug.Log(save);
                WinDelegate?.Invoke();
            }
        
        }
        
    }
