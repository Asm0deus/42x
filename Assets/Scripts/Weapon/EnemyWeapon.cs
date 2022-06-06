using UnityEngine;

public class EnemyWeapon : Gun
{
    public override void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _shootPeriod)
        {
            _timer = 0;
            Shoot();
            //Debug.Log("������� ����� - " + transform.root.gameObject.name);
        }
    }
}
