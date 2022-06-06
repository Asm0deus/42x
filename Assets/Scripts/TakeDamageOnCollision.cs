using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerBullet>())
            {
                _enemyHealth.TakeDamage(10);
                Debug.Log("��������� �� ����� - " + transform.root.gameObject.name);
            }
        }
    }
}
