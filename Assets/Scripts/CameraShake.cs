using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Quest
{
    public class CameraShake : MonoBehaviour
    { 
        
        [SerializeField] private Animation _animation;
        private void Start()
        {
            Hero.GetDamage += Shake;
        }

        public void Shake()
        {
            _animation.Play();
        }

        private void OnDestroy()
        {
            Hero.GetDamage -= Shake;
        }
    }
}