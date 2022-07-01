using UnityEngine;

public class PowerUpSpeed : PowerUp
{
    [SerializeField, Range(1.0f, 4.0f)] private float speedMultiplier = 2.0f;

    protected override void PowerUpPayload()          // Пункт 1 контрольного списка
    {
        base.PowerUpPayload();
        _unit.SetSpeedBoostOn(speedMultiplier);
    }

 
  
}
