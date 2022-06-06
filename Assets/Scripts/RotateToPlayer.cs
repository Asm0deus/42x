using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;
    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
