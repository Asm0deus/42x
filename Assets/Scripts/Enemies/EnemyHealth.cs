using UnityEngine;
using TMPro;

public class EnemyHealth : UnitsHealth
{
    [Space(5)]
    [Header("EnemyHP")]
    [SerializeField] private TMP_Text _textHP;
    [SerializeField] private Enemy _enemy;

    public override void UpdateHP()
    {
        base.UpdateHP();

        if (_textHP != null)
        {
            _textHP.text = _health.ToString("0");
            if (_health <= 0)
            {
                _textHP.text = "0";
                _enemy.SetState(EnemyState.Dead);
            }
        }
    }
}
