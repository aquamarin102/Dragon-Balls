using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class Coins : MonoBehaviour
    {
    private int _pickupCoin = 0;
        private void OnTriggerEnter(Collider other)
        {
            _pickupCoin++;
        }
    }
}
