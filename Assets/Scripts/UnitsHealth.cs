using UnityEngine;
using UnityEngine.UI;

public class UnitsHealth : MonoBehaviour
{
    [SerializeField] protected Slider _sliderHP;
    [SerializeField] protected float _health = 1;

    private void Start()
    {
        UpdateHP();
    }
    public void TakeDamage(float damageValue)
    {
        _health -= damageValue;
        UpdateHP();
    }
    public virtual void UpdateHP()
    {
        
        if (_health <= 0) _health = 0;
        _sliderHP.value = _health / 100f;
    }
}
