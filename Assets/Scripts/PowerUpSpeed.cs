using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : PowerUp
{
    [Range(1.0f, 4.0f)]
    public float speedMultiplier = 2.0f;

    protected override void PowerUpPayload()          // Пункт 1 контрольного списка
    {
        base.PowerUpPayload();
        _heroMove.SetSpeedBoostOn(speedMultiplier);
    }

 
  
}
