using UnityEngine;

    public class DamageTrap : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] private float _damage = 3f;

        [SerializeField, Range(0f, 15f), Tooltip("Push force")]
        private float _pushHit = 1f;

        public (float dmg, float push) GetHit()
            {
                return (_damage, _pushHit);
            }

        private void OnCollisionEnter(Collision collision)
        {
            DamageTrap hit = new DamageTrap();
            (float dmg, float push) trap = hit.GetHit();
            
            if (collision.gameObject.TryGetComponent(out IUnit health))
            {
                health.Hit(trap.dmg);
            }

            if (collision.gameObject.TryGetComponent(out Rigidbody rig))
            {
                rig.AddForce(transform.up * trap.push, ForceMode.VelocityChange);
                rig.AddForce(transform.forward * trap.push, ForceMode.VelocityChange);
            }
            
        }
    }

