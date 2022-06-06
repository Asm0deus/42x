using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 10f;
    [SerializeField] private float _friction = 1f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private LayerMask _groundLayerMask;

    [SerializeField] private float _maxInputSpeed = 6f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) _rb.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (_isGrounded == false)
        {
            speedMultiplier = 0.01f;

            if (_rb.velocity.x > _maxInputSpeed && Input.GetAxis("Horizontal") > 0 || _rb.velocity.z > _maxInputSpeed && Input.GetAxis("Vertical") > 0)
            {
                speedMultiplier = 0;
            }
            if (_rb.velocity.x < -_maxInputSpeed && Input.GetAxis("Horizontal") < 0 || _rb.velocity.z < -_maxInputSpeed && Input.GetAxis("Vertical") < 0)
            {
                speedMultiplier = 0;
            }
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _rb.AddForce(move * _moveSpeed * speedMultiplier, ForceMode.VelocityChange);

        //ѕротиводействующа€ скорость, типа сопротивление воздуха, но локальное. “олько если на земле.
        if (_isGrounded)
        {
            _rb.AddForce(-_rb.velocity.x * _friction, 0, -_rb.velocity.z * _friction, ForceMode.VelocityChange);
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        //„тобы не битьс€ об стены
        //¬ычисление угла между нормалью контактной поверхности и вектором вверх (Y) по всем точкам
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);

            if (angle <= 45f)
            {
                _isGrounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
}
