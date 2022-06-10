using UnityEngine;

namespace Quest
{


    public class DamageTrap : MonoBehaviour
    {
        [SerializeField] private float damage = 3f;
        [SerializeField] private float _expHit = 1f;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Hero health))
            {
                health.Hit(damage);
            }

            if (collision.gameObject.TryGetComponent(out Rigidbody rig))
            {
                rig.AddForce(transform.up * _expHit, ForceMode.VelocityChange);
                rig.AddForce(transform.forward * _expHit, ForceMode.VelocityChange);
            }
            
        }
    }
}
