using UnityEngine;

namespace Quest
{
    public class MouseLook : MonoBehaviour
    {
        public enum RotatetionAxis
        {
            XandY,
            X,
            Y
        }
        public RotatetionAxis _axes = RotatetionAxis.XandY;
        [SerializeField] private float _rotationSpeedHor = 5f;
        [SerializeField] private float _rotationSpeedVer = 5f;

        [SerializeField] private float _maxVert = 45f;
        [SerializeField] private float _minVert = -45f;

        private float _rotationX = 0;

        private void Start()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null)
            {
                body.freezeRotation = true;
            }
        }
        
        private void Update()
        {
            if (_axes == RotatetionAxis.XandY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
                _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

                float delta = Input.GetAxis("Mouse X") * _rotationSpeedHor;
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else if (_axes == RotatetionAxis.X)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * _rotationSpeedHor, 0);
            }
            else if (_axes == RotatetionAxis.Y)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
                _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}