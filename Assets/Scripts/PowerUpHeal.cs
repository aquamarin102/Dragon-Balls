using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeal : PowerUp
{
    [SerializeField] private float _healthBonus = 20;

    protected override void PowerUpPayload()  // Пункт 1 контрольного списка
    {
        base.PowerUpPayload();

        // Полезная нагрузка заключается в добавлении здоровья
        _unit.SetHealthAdjustment(_healthBonus);
    }
}
