using UnityEngine;

[RequireComponent(typeof(Pool))]
public class Gun : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] protected float _shootPeriod = 0.2f;

    [SerializeField] private GameObject _flash;

    [SerializeField] protected AudioSource _shootSound;

    protected float _timer;
    private Pool _pool;
    private void Start()
    {
        _pool = GetComponent<Pool>();
    }

    public virtual void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _shootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                Shoot();
                Debug.Log("Выстрел игрока");
            }
        }
    }

    public virtual void Shoot()
    {
        _pool.GetFreeElement(_spawnPoint.position, _spawnPoint.rotation);
        _shootSound.Play();
        _flash.SetActive(true);

        Invoke(nameof(HideFlash), 0.12f);
    }

    public void HideFlash()
    {
        _flash.SetActive(false);
    }
}
