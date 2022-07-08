using UnityEngine;

public  class PowerUpHeal : PowerUp
{
    [SerializeField, Range(1f, 10f)] private float _healthBonus = 3f;

    protected override void PowerUpPayload()  // Пункт 1 контрольного списка
    {
        base.PowerUpPayload();

        // Полезная нагрузка заключается в добавлении здоровья
        _unit.SetHealthAdjustment(_healthBonus);
    }
}
