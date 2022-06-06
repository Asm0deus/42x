using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private Vector3 LeftEuler;
    [SerializeField] private Vector3 RightEuler;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private Transform EnemyModel;

    private Vector3 _targetEuler;

    void Update()
    {
        EnemyModel.transform.localRotation = Quaternion.Lerp(EnemyModel.transform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler = LeftEuler;
    }
    public void RotateRight()
    {
        _targetEuler = RightEuler;
    }
}
