using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidBody;

    [SerializeField]
    private Animator _playerAnimator;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _jumpSpeed, jumpFrequency, nextJumpTime;

    private bool _facingRight = true;
    public bool _isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Start()
    {
        if (_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        if (_playerAnimator == null)
        {
            _playerAnimator = GetComponent<Animator>();
        }
        
    }

    void Update()
    {
        HorizantalMove();
        OnGroundCheck();

        if (_rigidBody.velocity.x < 0 && _facingRight)
        {
            FlipFace();
        }
        else if (_rigidBody.velocity.x > 0 && !_facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && _isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    private void HorizantalMove()
    {
        _rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, _rigidBody.velocity.y);
        _playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(_rigidBody.velocity.x));
    }

    private void FlipFace()
    {
        _facingRight = !_facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    private void Jump()
    {
        _rigidBody.AddForce(new Vector2(0f, _jumpSpeed));
    }

    private void OnGroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        _playerAnimator.SetBool("isGroundedAnim", _isGrounded);
    }
}
