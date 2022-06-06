using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNoPhysics : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] private float _speed = 4f;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = .5f;

    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _distanceToGround = .4f;
    [SerializeField] private LayerMask _groundLayerMask;

    private Vector3 _velocity;
    private bool _isGrounded;
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, _distanceToGround, _groundLayerMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _characterController.Move(move * _speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);

    }
}
