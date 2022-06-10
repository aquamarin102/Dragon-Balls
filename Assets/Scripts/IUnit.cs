using UnityEngine;

namespace Quest
{
    public interface IUnit
    {
        void SetSpeedBoostOn(float speed);
        void SetHealthAdjustment(float heal);
        void GetCoin(GameObject coin);
    }
}