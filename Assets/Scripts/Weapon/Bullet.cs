using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _bulletSpeed = 10f;

    [SerializeField] private GameObject _effectPrefab;

    private PoolObject _poolObject;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _poolObject = GetComponent<PoolObject>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + transform.forward * _bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        
        if (collision.rigidbody)
        {
            PlayerMovement player = collision.rigidbody.GetComponent<PlayerMovement>();
            if (player) collision.rigidbody.AddForce(transform.position * 4f, ForceMode.VelocityChange);
        }

        _poolObject.ReturnToPool();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        _poolObject.ReturnToPool();
    }
}
