using UnityEngine;

    public class DamageTrap : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] private float _damage = 3f;
        [SerializeField, Range(0f, 15f), Tooltip("Push force")] private float _pushHit = 1f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IUnit health))
            {
                health.Hit(_damage);
            }

            if (collision.gameObject.TryGetComponent(out Rigidbody rig))
            {
                rig.AddForce(transform.up * _pushHit, ForceMode.VelocityChange);
                rig.AddForce(transform.forward * _pushHit, ForceMode.VelocityChange);
            }
            
        }
    }

