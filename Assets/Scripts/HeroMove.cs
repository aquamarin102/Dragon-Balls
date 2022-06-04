using UnityEngine;

namespace Quest
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _runspeed = 10f;
        [SerializeField] private float _jumpForce = 200f;
        [SerializeField] private GameObject _viewCamera;
        
        private Rigidbody _rigidbody;
        
        private bool _isRunning;
        private float _deltaX, _deltaZ;
        
        private const string _horizontal = "Horizontal";
        private const string  _vertical = "Vertical";
        private const string _jump = "Jump";

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {

            _deltaX = Input.GetAxis(_horizontal) * (_isRunning ? _runspeed : _speed);
            _deltaZ = Input.GetAxis(_vertical) * (_isRunning ? _runspeed : _speed);

            _rigidbody.AddTorque(Vector3.back * _deltaX);
            _rigidbody.AddTorque(Vector3.right * _deltaZ);
            if (Input.GetButtonDown(_jump)) 
            {
                _rigidbody.AddForce(Vector3.up*_jumpForce);
            }
            
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
    }
}